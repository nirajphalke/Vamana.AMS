import { HttpClient } from '@angular/common/http';

import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({ providedIn: 'root' })
export class MasterService {
    //private base = 'https://localhost:44309/api/master';
    private readonly baseUrl = environment.apiBaseUrl; // e.g. "https://api.example.com"

    constructor(private http: HttpClient) { }

    getMaster(masterName: string): Observable<any[]> {
        return this.http.get<any[]>(`${this.baseUrl}/master/${masterName}`);
    }

    getAll(masterName: string): Observable<any[]> {
        return this.http.get<any[]>(`${this.baseUrl}/${masterName}`);
    }

    //   getLookup(masterName: string): Observable<any[]> {
    //     return this.http.get<any[]>(`${this.baseUrl}/lookup/${masterName}`);
    //   }

    getLookup(masterName: string | null | undefined): Observable<any[]> {
        if (!masterName) {
            console.warn('getLookup called with invalid key:', masterName);
            return of([]); // ✅ never return null
        }

        return this.http.get<any[]>(`${this.baseUrl}/master/lookup/${masterName}`);
    }

    get(endpoint: string, id: number) {
        return this.http.get<any>(`${this.baseUrl}/master/${endpoint}/${id}`);
    }

    create(endpoint: string, payload: any) {
        return this.http.post(`${this.baseUrl}/master/${endpoint}`, payload);
    }

    update(endpoint: string, id: number, payload: any) {
        return this.http.put(`${this.baseUrl}/master/${endpoint}/${id}`, payload);
    }

    delete(endpoint: string, id: number) {
        return this.http.delete(`${this.baseUrl}/master/${endpoint}/${id}`);
    }

    postStudent(payload: any) {
        return this.http.post(`${this.baseUrl}/student/add`, payload);
    }

    getReceiptTypes(): Observable<any[]> {
        return this.http.get<any[]>(`${this.baseUrl}/master/receiptType`);
    }

    postReceiptType(payload: any) {
        return this.http.post(`${this.baseUrl}/master/receiptType`, payload);
    }

    updateReceiptType(id: number, payload: any) {
        return this.http.put(`${this.baseUrl}/master/receiptType/${id}`, payload);
    }

    private buildUrl(endpoint: string, id?: string | number): string {
        let url = `${this.baseUrl.replace(/\/+$/, '')}/${endpoint}`;
        if (id !== undefined && id !== null) {
            url += `/${id}`;
        }
        return url;
    }   


}
