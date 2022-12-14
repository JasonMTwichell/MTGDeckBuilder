import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms'
import { MatFormFieldModule } from '@angular/material/form-field'
import { MatInputModule } from '@angular/material/input'
import { MatCheckboxModule } from '@angular/material/checkbox'
import { MatSelectModule } from '@angular/material/select'
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { MatButtonModule } from '@angular/material/button';
import { AppComponent } from './app.component';
import { CardSearchComponent } from './components/card-search/card-search.component';
import { MainSearchComponent } from './pages/main-search/main-search.component';
import { ActionableResultListComponent } from './components/actionable-result-list/actionable-result-list.component'
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';
import { MatMenuModule } from '@angular/material/menu';
import { MatIconModule } from '@angular/material/icon';
import { EditListDialogComponent } from './components/edit-list-dialog/edit-list-dialog.component';
import { ListManagerComponent } from './components/list-manager/list-manager.component';
import { MatListModule } from '@angular/material/list'
import { MatDialogModule } from '@angular/material/dialog';
import { ConfirmDialogComponent } from './components/confirm-dialog/confirm-dialog.component';
import { DeckManagerComponent } from './components/deck-manager/deck-manager.component'

@NgModule({
  declarations: [
    AppComponent,
    CardSearchComponent,
    MainSearchComponent,
    ActionableResultListComponent,    
    EditListDialogComponent, ListManagerComponent, ConfirmDialogComponent, DeckManagerComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatSlideToggleModule,
    MatCheckboxModule,
    MatSelectModule,
    MatButtonModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    MatMenuModule,
    MatIconModule,
    MatListModule,
    MatDialogModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
