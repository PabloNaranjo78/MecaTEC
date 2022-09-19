import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InfoTrabajadorComponent } from './info-trabajador.component';

describe('InfoTrabajadorComponent', () => {
  let component: InfoTrabajadorComponent;
  let fixture: ComponentFixture<InfoTrabajadorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ InfoTrabajadorComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(InfoTrabajadorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
