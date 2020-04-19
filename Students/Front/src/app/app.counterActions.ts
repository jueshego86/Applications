import { createAction, props } from '@ngrx/store'

export const setCount = createAction('SetCount',
    props<{ count: number }>()
);