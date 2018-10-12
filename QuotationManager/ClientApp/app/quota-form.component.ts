import { Component, Input } from '@angular/core';
import { Quota } from './quota';
import { City } from './city';
import { Purpose } from './purpose';
@Component({
    selector: "quota-form",
    templateUrl: './views/quota-form.component.html'
})
export class QuotaFormComponent {
    @Input() quota: Quota;
    @Input() cities: City[];
    @Input() purposes: Purpose[];
}