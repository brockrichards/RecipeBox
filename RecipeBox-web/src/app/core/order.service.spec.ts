import { TestBed } from '@angular/core/testing';
import { RecipeBoxClient } from '../api/shopping-cart/shopping-cart.client';

import { OrderService } from './order.service';

describe('OrderService', () => {
    let service: OrderService;

    beforeEach(() => {
        TestBed.configureTestingModule({
            providers: [{ provide: RecipeBoxClient, useValue: {} }],
        });
        service = TestBed.inject(OrderService);
    });

    it('should be created', () => {
        expect(service).toBeTruthy();
    });
});

