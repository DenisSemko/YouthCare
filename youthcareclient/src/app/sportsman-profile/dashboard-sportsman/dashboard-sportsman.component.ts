import { Component, OnInit } from '@angular/core';
import { AnalysisService } from 'src/app/shared/analysis.service';

@Component({
  selector: 'app-dashboard-sportsman',
  templateUrl: './dashboard-sportsman.component.html',
  styleUrls: ['./dashboard-sportsman.component.scss']
})
export class DashboardSportsmanComponent implements OnInit {

  constructor(public service: AnalysisService) { }

  ngOnInit(): void {
  }

}
