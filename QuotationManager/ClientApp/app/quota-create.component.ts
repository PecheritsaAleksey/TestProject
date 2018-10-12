import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { DataService } from './data.service';
import { DataServiceCity } from './data.service.city';
import { DataServicePurpose } from './data.service.purpose';
import { Quota } from './quota';
import { City } from './city';
import { Purpose } from './purpose';

@Component({
    templateUrl: './views/quota-create.component.html'
})
export class QuotaCreateComponent {

    quota: Quota = new Quota();
    cities: City[];
    purposes: Purpose[];

    constructor(private dataService: DataService, private dataServiceCity: DataServiceCity, private dataServicePurpose: DataServicePurpose, private router: Router) { }

    ngOnInit() {
        this.dataServiceCity.getCities().subscribe((data: City[]) =>  this.cities = data);
        this.dataServicePurpose.getPurposes().subscribe((data: Purpose[]) => this.purposes = data);
    }

    save() {
        this.dataService.createQuota(this.quota).subscribe(data => this.router.navigateByUrl("/"));
    }
}