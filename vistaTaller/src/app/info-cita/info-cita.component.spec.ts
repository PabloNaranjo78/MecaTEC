import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InfoCitaComponent } from './info-cita.component';

describe('InfoCitaComponent', () => {
  let component: InfoCitaComponent;
  let fixture: ComponentFixture<InfoCitaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ InfoCitaComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(InfoCitaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
