import { Component, EventEmitter, Input, Output, Type, ViewChild, ViewContainerRef, OnChanges, SimpleChanges } from '@angular/core';


@Component({
    selector: 'app-slider',
    template: `
    <div class="slider-container" 
        [class.open]="isOpen"
        [style.top]="top"
        [style.height]="height"
        [style.width]="width">

        <!-- HEADER -->
        <div class="slider-header">
            <h3 class="slider-title">{{ title }}</h3>
            <button class="close-btn" (click)="close()">✖</button>
        </div>

        <!-- CONTENT -->
        <div class="slider-content">
            <ng-template #dynamicContainer></ng-template>
        </div>
    </div>
  `,
    styles: [`
    .slider-backdrop {
        position: fixed;
        inset: 0;
        background: rgba(0, 0, 0, 0.4);
        z-index: 500;
    }

    .slider-container {
        position: fixed;
        top: 0;
        right: 0;
        //width: 500px; /* or dynamic width */
        //height: 100vh;
        background: #fff;
        //box-shadow: -2px 0 6px rgba(0, 0, 0, 0.2);
        box-shadow: -6px 0 12px rgba(0,0,0,0.25);
        border: 2px solid lightgray;
        z-index: 500;
        transition: transform 0.3s ease-in-out;
        transform: translateX(100%);   /* always fully hidden */
        display: flex;
        flex-direction: column;
    }

    .slider-container.open {
        transform: translateX(0);      /* slide into view */
    }

    .slider-header {
        display: flex;
        justify-content: space-between;
        align-items: center;
        padding: 10px 16px;
        border-bottom: 1px solid #eee;
        background: #f9f9f9;
    }

    .slider-title {
        margin: 0;
        font-size: 18px;
        font-weight: 600;
        //color: #6459ED;
    }

    .close-btn {
        font-size: 22px;
        background: none;
        border: none;
        cursor: pointer;
        line-height: 1;
    }

    .slider-content {
        flex: 1;
        //overflow-y: auto;
        padding: 15px;
    }
  `],
    standalone: true
})
export class SliderComponent implements OnChanges {
    @Input() title: string = '';
    @Input() top: string = '0px';
    @Input() height: string = '100vh';
    @Input() width: string = '500px';
    @Input() isOpen = false;
    @Input() componentType?: Type<any>;
    @Input() data?: any;
    @Output() closed = new EventEmitter<any>();

    @ViewChild('dynamicContainer', { read: ViewContainerRef }) dynamicContainer!: ViewContainerRef;

    ngOnChanges(changes: SimpleChanges): void {
        //if (changes['componentType'] && this.isOpen) {
        this.loadComponent();
        //}
    }

    loadComponent() {
        if (!this.dynamicContainer) return;
        this.dynamicContainer.clear();
        if (this.componentType) {
            const compRef = this.dynamicContainer.createComponent(this.componentType);
            if (this.data) {
                Object.assign(compRef.instance, this.data);
            }
            if ((compRef.instance as any).onClose) {
                (compRef.instance as any).onClose.subscribe((val: any) => {
                    this.close(val);
                });
            }
        }
    }

    close(result?: any) {
        this.isOpen = false;
        this.closed.emit(result);
        this.dynamicContainer.clear();
    }
}