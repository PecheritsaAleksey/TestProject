import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Quota } from './quota';

@Injectable()
export class DataService {

    private url = "/api/quotas";

    constructor(private http: HttpClient) {
    }

    getQuotas() {
        return this.http.get(this.url);
    }

    getQuota(id: number) {
        return this.http.get(this.url + '/' + id);
    }

    createQuota(quota: Quota) {
        return this.http.post(this.url, quota);
    }

    updateQuota(quota: Quota) {
        return this.http.put(this.url + '/' + quota.id, quota);
    }

    deleteQuota(id: number) {
        return this.http.delete(this.url + '/' + id);
    }
}