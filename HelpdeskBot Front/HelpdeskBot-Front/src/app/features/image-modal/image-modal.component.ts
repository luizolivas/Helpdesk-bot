import { CommonModule } from '@angular/common';
import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogContent, MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-image-modal',
  standalone: true,
  imports: [CommonModule,MatDialogContent],
  templateUrl: './image-modal.component.html',
  styleUrl: './image-modal.component.css'
})
export class ImageModalComponent {

  constructor(@Inject(MAT_DIALOG_DATA) public data: { imageUrl: string }, private dialogRef: MatDialogRef<ImageModalComponent>) {}

  onClose(): void {
    this.dialogRef.close(); 
  }
}
