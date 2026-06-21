import { Component, EventEmitter, Output } from '@angular/core';
import { ICellRendererAngularComp } from 'ag-grid-angular';
import { ICellRendererParams } from 'ag-grid-community';
import { MatIconModule } from '@angular/material/icon';

@Component({
    selector: 'app-icon-button-renderer',
    template: `
    <button (click)="onClick()" class="icon-button">
      <mat-icon>{{ iconName }}</mat-icon> <!-- Using Angular Material Icon -->
    </button>
  `,
    styles: [`
    .icon-button {
      background: none;
      border: none;
      padding: 0;
      cursor: pointer;
    }
  `],
    imports: [MatIconModule]
})
export class IconButtonRendererComponent implements ICellRendererAngularComp {
    iconName: string = 'edit'; // Default icon, can be overridden by params
    private params!: ICellRendererParams & { onClick?: (value: any) => void };


    agInit(params: ICellRendererParams): void {
        this.params = params;
        if (params.colDef?.cellRendererParams?.icon) {
            this.iconName = params.colDef.cellRendererParams.icon;
        }
    }

    refresh(params: ICellRendererParams): boolean {
        return false; // No refresh needed for this simple component
    }

    onClick(): void {
        this.params.onClick(this.params.data);  // 👈 emit to AppComponent

    }
}