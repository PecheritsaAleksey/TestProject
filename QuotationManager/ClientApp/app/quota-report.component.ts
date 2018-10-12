import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { DataServiceReport } from './data.service.report';
import { Quota } from './quota';

@Component({
    templateUrl: './views/quota-detail.component.html',
    providers: [DataServiceReport]
})
export class QuotaReportComponent implements OnInit {

    id: number;
    quota: Quota;
    loaded: boolean = false;

    constructor(private dataService: DataServiceReport, activeRoute: ActivatedRoute) {
        this.id = Number.parseInt(activeRoute.snapshot.params["id"]);
    }

    ngOnInit() {
        if (this.id)
            this.dataService.getReport(this.id)
                .subscribe();
    }
}