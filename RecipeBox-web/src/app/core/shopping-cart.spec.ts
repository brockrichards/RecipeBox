import { TestBed } from '@angular/core/testing';

import { RecipeBox } from './shopping-cart';

describe('RecipeBox', () => {
    let service: RecipeBox;

    beforeEach(() => {
        TestBed.configureTestingModule({});
        service = TestBed.inject(RecipeBox);
    });

    it('should be created', () => {
        expect(service).toBeTruthy();
    });
});

