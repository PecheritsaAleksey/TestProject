import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { DataService } from './data.service';
import { Quota } from './quota';

@Component({
    templateUrl: './views/quota-detail.component.html',
    providers: [DataService]
})
export class QuotaDetailComponent implements OnInit {

    id: number;
    quota: Quota;
    loaded: boolean = false;

    constructor(private dataService: DataService, activeRoute: ActivatedRoute) {
        this.id = Number.parseInt(activeRoute.snapshot.params["id"]);
    }

    ngOnInit() {
        if (this.id)
            this.dataService.getQuota(this.id)
                .subscribe((data: Quota) => { this.quota = data; this.loaded = true; console.log(data); console.log(this.quota)});
    }
}