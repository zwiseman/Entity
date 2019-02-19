import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatDialogModule, MatFormFieldModule, MatInputModule, MAT_LABEL_GLOBAL_OPTIONS, MatButtonModule } from '@angular/material';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppComponent } from './app.component';
import { Pipes } from 'pipes/index';
import { Services } from 'services/index';
import { Components, EditEmployeeComponent } from 'components/index';
import { CreateEmployeeComponent } from 'components/create-employee/create-employee.component';

@NgModule({
  declarations: [
    AppComponent,
    Components,
    Pipes
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule,
    MatDialogModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule
  ],
  providers: [
    Services,
    {provide: MAT_LABEL_GLOBAL_OPTIONS, useValue: {float: 'always'}}
   ],
  bootstrap: [AppComponent],
  entryComponents: [ EditEmployeeComponent, CreateEmployeeComponent ]
})
export class AppModule { }
