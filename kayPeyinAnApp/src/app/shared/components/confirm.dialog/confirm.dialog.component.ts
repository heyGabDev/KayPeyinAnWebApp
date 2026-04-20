import { Component, inject } from "@angular/core";
import { MatButtonModule } from '@angular/material/button';
import { MAT_DIALOG_DATA, MatDialogModule, MatDialogRef } from '@angular/material/dialog';

export interface ConfirmDialogData {
  title: string;
  message: string;  
  confirmLabel?: string;
  cancelLabel?: string;
}

@Component({
  selector: 'app-confirm.dialog.component',
  standalone: true,
  imports: [MatDialogModule, MatButtonModule],
  templateUrl: './confirm.dialog.component.html',
  styleUrl: './confirm.dialog.component.css'
})
export class ConfirmDialogComponent {

  data = inject(MAT_DIALOG_DATA) as ConfirmDialogData;
  dialogRef = inject(MatDialogRef<ConfirmDialogComponent>);

  confirm() {
    this.dialogRef.close(true);
  }

  cancel() {
    this.dialogRef.close(false);
  }

}
