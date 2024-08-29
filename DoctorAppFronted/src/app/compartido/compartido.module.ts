import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { LayoutComponent } from './layout/layout.component';
import { DashbordComponent } from './dashbord/dashbord.component';
import { MaterialModule} from '../material/material.module'

@NgModule({
  declarations: [
    LayoutComponent,
    DashbordComponent
  ],
  imports: [
    CommonModule,
    MaterialModule
  ],
  exports: [
    ReactiveFormsModule, FormsModule, HttpClientModule, LayoutComponent, DashbordComponent
  ]
})
export class CompartidoModule { }
