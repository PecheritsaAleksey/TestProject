import { Component, OnInit } from '@angular/core';
import { DataService } from './data.service';
import { Quota } from './quota';

@Component({
    templateUrl: './views/quota-list.component.html'
})
export class QuotaListComponent implements OnInit {

    quotas: Quota[];
    constructor(private dataService: DataService) { }

    ngOnInit() {
        this.load();
    }
    load() {
        this.dataService.getQuotas().subscribe((data: Quota[]) => this.quotas = data);
    }
    delete(id: number) {
        this.dataService.deleteQuota(id).subscribe(data => this.load());
    }
}