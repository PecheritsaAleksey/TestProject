import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { Routes, RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { QuotaListComponent } from './quota-list.component';
import { QuotaFormComponent } from './quota-form.component';
import { QuotaCreateComponent } from './quota-create.component';
import { QuotaEditComponent } from './quota-edit.component';
import { QuotaDetailComponent } from './quota-detail.component';
import { QuotaReportComponent } from './quota-report.component';
import { NotFoundComponent } from './not-found.component';

import { DataService } from './data.service';
import { DataServiceCity } from './data.service.city';
import { DataServicePurpose } from './data.service.purpose';
// определение маршрутов
const appRoutes: Routes = [
    { path: '', component: QuotaListComponent },
    { path: 'quota/:id', component: QuotaDetailComponent },
    { path: 'report/:id', component: QuotaReportComponent },
    { path: 'create', component: QuotaCreateComponent },
    { path: 'edit/:id', component: QuotaEditComponent },
    { path: '**', component: NotFoundComponent }
];

@NgModule({
    imports: [BrowserModule, FormsModule, HttpClientModule, RouterModule.forRoot(appRoutes)],
    declarations: [AppComponent, QuotaListComponent, QuotaReportComponent, QuotaDetailComponent, QuotaCreateComponent, QuotaEditComponent,
        QuotaFormComponent, NotFoundComponent],
    providers: [DataService, DataServiceCity, DataServicePurpose],
    bootstrap: [AppComponent]
})
export class AppModule { }