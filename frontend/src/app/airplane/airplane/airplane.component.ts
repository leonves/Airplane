import { Component, OnInit, ViewChild } from '@angular/core';
import { Airplane } from './shared/airplane.model';
import { MatPaginator, MatTableDataSource, MatSort, MatTable } from '@angular/material';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { AirplaneService } from './shared/airplane.service';
import { HttpEventType } from '@angular/common/http';
import { Router } from "@angular/router";
import { AvisoService } from 'src/app/services/aviso.service';

@Component({
  selector: 'app-airplane',
  templateUrl: './airplane.component.html',
  styleUrls: ['./airplane.component.scss']
})
export class AirplaneComponent implements OnInit {
  message: string;
  constructor(private airplaneService: AirplaneService,
    private router: Router,
    private avisoService: AvisoService) { 
  }

    aircrafts: any[];

    displayedColumns: string[] = ['Código do Avião', 'Modelo', 'Passageiros', 'Data de Criação', 'Opções'];
    isLoading = true;
    dataSource = null;

    @ViewChild(MatPaginator) paginator: MatPaginator;
    @ViewChild(MatSort) sort: MatSort;
    @ViewChild(MatTable) matTable: MatTable<any>;

    aircraft: any;


  ngAfterViewInit() {
    this.airplaneService.get().subscribe(data => {
      this.aircrafts = data;
      this.isLoading = false;
      this.dataSource = new MatTableDataSource(this.aircrafts);
      this.dataSource.paginator = this.paginator;
    }, error => {
      this.avisoService.avisar("Erro ao carregar os arquivos: " + error.message);
    })
  }

  signoff() {
    this.router.navigate(['/login']);
    localStorage.clear();
  }

  remover(id: string) {
    this.isLoading = true;
    this.airplaneService.delete(id).subscribe((data)=>{
      this.ngAfterViewInit();
      
      this.isLoading = false;
    });
    debugger;
  }
  ngOnInit() {
    this.aircrafts = [];
  }
}
