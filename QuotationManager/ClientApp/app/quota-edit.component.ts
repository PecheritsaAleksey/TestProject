import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { DataService } from './data.service';
import { DataServiceCity } from './data.service.city';
import { DataServicePurpose } from './data.service.purpose';
import { Quota } from './quota';
import { City } from './city';
import { Purpose } from './purpose';

@Component({
    templateUrl: './views/quota-edit.component.html'
})
export class QuotaEditComponent implements OnInit {

    id: number;
    quota: Quota;    // изменяемый объект
    loaded: boolean = false;
    cities: City[];
    purposes: Purpose[];

    constructor(private dataService: DataService, private dataServiceCity: DataServiceCity, private dataServicePurpose: DataServicePurpose, private router: Router, activeRoute: ActivatedRoute) {
        this.id = Number.parseInt(activeRoute.snapshot.params["id"]);
    }

    ngOnInit() {
        if (this.id)
            this.dataService.getQuota(this.id)
                .subscribe((data: Quota) => {
                    this.quota = data;
                    if (this.quota != null) this.loaded = true;
                });
        this.dataServiceCity.getCities().subscribe((data: City[]) => this.cities = data);
        this.dataServicePurpose.getPurposes().subscribe((data: Purpose[]) => this.purposes = data);
    }

    save() {
        this.dataService.updateQuota(this.quota).subscribe(data => this.router.navigateByUrl("/"));
    }
}