import { HttpHandlerFn } from "@angular/common/http";
import { HttpEvent, HttpEventType, HttpRequest } from "@angular/common/http";
import { Observable, tap } from "rxjs";

export function authInterceptor(req: HttpRequest<unknown>, next: HttpHandlerFn) {
    // Inject the current `AuthService` and use it to get an authentication token:
    // Get the token from a storage mechanism (e.g., localStorage, a service)
    const authToken = localStorage.getItem('auth_token');
    //const authToken = inject(AuthService).getAuthToken();

    // Clone the request to add the authentication header.
    const newReq = req.clone({
        headers: req.headers.append('X-Authentication-Token', authToken),
    });
    return next(req);
}

// export function loggingInterceptor(req: HttpRequest<unknown>, next: HttpHandlerFn): Observable<HttpEvent<unknown>> {
//     return next(req).pipe(tap(event => {
//         if (event.type === HttpEventType.Response) {
//             console.log(req.url, 'returned a response with status', event.status);
//         }
//     }));
// }
