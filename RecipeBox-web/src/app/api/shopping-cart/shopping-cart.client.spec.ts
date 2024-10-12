import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { RecipeBoxClient } from './shopping-cart.client';
import { AppConfig } from 'src/environments/app-config';

describe('RecipeBoxClient', () => {
    let service: RecipeBoxClient;

    beforeEach(() => {
        TestBed.configureTestingModule({
            imports: [HttpClientTestingModule],
            providers: [{ provide: AppConfig, useValue: {} }],
        });
        service = TestBed.inject(RecipeBoxClient);
    });

    it('should be created', () => {
        expect(service).toBeTruthy();
    });
});

