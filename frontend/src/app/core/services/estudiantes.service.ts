import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

export interface Estudiante {
  id: number;
  nombre: string;
  email?: string;
  cantidadNotas: number;
}

@Injectable({
  providedIn: 'root'
})
export class EstudiantesService {

  private apiUrl = 'https://localhost:56548/api/Estudiantes';

  constructor(private http: HttpClient) {}

  getAll(): Observable<Estudiante[]> {
    return this.http.get<Estudiante[]>(this.apiUrl);
  }

  create(estudiante: Partial<Estudiante>): Observable<Estudiante> {
    return this.http.post<Estudiante>(this.apiUrl, estudiante);
  }

  update(id: number, estudiante: Partial<Estudiante>): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${id}`, estudiante);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
