import {Component, Inject} from '@angular/core';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material';

@Component({
    selector: 'dialog-geral',
    templateUrl: 'dialog-geral.html',
  })
  export class DialogGeral {
  
    constructor(
      public dialogRef: MatDialogRef<DialogGeral>,
      @Inject(MAT_DIALOG_DATA) public data: any) { }
  
    onNoClick(): void {
      this.dialogRef.close();
    }
}
