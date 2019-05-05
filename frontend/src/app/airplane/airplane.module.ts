import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { AirplaneRoutingModule } from './airplane-routing.module';
import { AirplaneComponent } from './airplane/airplane.component';

import { MatToolbarModule } from '@angular/material/toolbar';
import { MatDividerModule } from '@angular/material/divider';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';

import {
  MatButtonModule,
  MatSlideToggleModule,
  MatCardModule,
  MatDatepickerModule,
  MatDialogModule,
  MatNativeDateModule,
  MatInputModule,
  MatMenuModule,
  MatSelectModule,
  MatSidenavModule,
  MatSnackBarModule,
  MatFormFieldModule,
  MatGridListModule,
  MatTableModule,
  MatButtonToggleModule,
  MatIconModule,
  MatPaginatorModule
} from '@angular/material';
import { AirplaneCriarComponent } from './airplane-criar/airplane-criar.component';

@NgModule({
  declarations: [AirplaneComponent, AirplaneCriarComponent],
  imports: [
    CommonModule,
    AirplaneRoutingModule,
    MatButtonModule,
    MatSlideToggleModule,
    MatCardModule,
    MatDatepickerModule,
    MatDialogModule,
    MatNativeDateModule,
    MatInputModule,
    MatMenuModule,
    MatSelectModule,
    MatSidenavModule,
    MatSnackBarModule,
    MatFormFieldModule,
    MatGridListModule,
    MatTableModule,
    MatButtonToggleModule,
    MatIconModule,
    MatPaginatorModule,
    MatToolbarModule,
    MatDividerModule,
    FormsModule,
    MatProgressSpinnerModule
  ]
})
export class AirplaneModule { }
