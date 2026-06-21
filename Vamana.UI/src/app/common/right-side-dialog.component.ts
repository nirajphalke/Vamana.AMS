import { Component, ComponentRef, Injector, OnDestroy, OnInit, Type, ViewChild, ViewContainerRef, Inject } from '@angular/core';
import { trigger, transition, style, animate } from '@angular/animations';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

@Component({
    selector: 'app-right-side-dialog',
    template: `
    <div class="dialog-container" [@slideInOut]>
      <ng-container #container></ng-container>
    </div>
  `,
    styles: [`
    .dialog-container {
      position: fixed;
      top: 60px;
      right: 0;
      height: calc(100vh - 60px);
      width: 400px;
      background: white;
      border-left: 1px solid #ddd;
      border-radius: 0;
      box-shadow: -2px 0 6px rgba(0,0,0,0.2);
      overflow-y: auto;
    }
  `],
    animations: [
        trigger('slideInOut', [
            transition(':enter', [
                style({ transform: 'translateX(100%)' }),
                animate('400ms ease-out', style({ transform: 'translateX(0%)' }))
            ]),
            transition(':leave', [
                animate('400ms ease-in', style({ transform: 'translateX(100%)' }))
            ])
        ])
    ]
})
export class RightSideDialogComponent implements OnInit, OnDestroy {
    @ViewChild('container', { read: ViewContainerRef, static: true })
    container!: ViewContainerRef;

    private componentRef?: ComponentRef<any>;

    constructor(
        private dialogRef: MatDialogRef<RightSideDialogComponent>,
        @Inject(MAT_DIALOG_DATA) public data: { componentType: Type<any>; componentData?: any }
    ) { }

    ngOnInit() {
        this.container.clear();
        const injector = Injector.create({
            providers: [{ provide: MatDialogRef, useValue: this.dialogRef }]
        });

        // ✅ Dynamically create your child component
        this.componentRef = this.container.createComponent(this.data.componentType, {
            injector
        });

        if (this.data.componentData) {
            Object.assign(this.componentRef.instance, this.data.componentData);
        }

        // ✅ If child emits closeDialog event, close parent
        const instance: any = this.componentRef.instance;
        if (instance.closeDialog && instance.closeDialog.subscribe) {
            instance.closeDialog.subscribe((result: any) => {
                this.dialogRef.close(result);
            });
        }
    }

    ngOnDestroy() {
        this.componentRef?.destroy();
    }
}
