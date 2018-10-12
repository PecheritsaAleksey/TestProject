import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class DataServiceReport {

    private url = "/api/report";

    constructor(private http: HttpClient) {
    }

    getReport(id: number) {
        return this.http.get(this.url + '/' + id);
    }
}