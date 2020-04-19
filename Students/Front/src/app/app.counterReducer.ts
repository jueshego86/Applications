import { createReducer, on } from '@ngrx/store';
import * as states from './app.counterActions';
 
export const initialState = 0;
 
const _counterReducer = createReducer(initialState,
  on(states.setCount, (state, { count }) => count)
);
 
export function counterReducer(state, action) {
  return _counterReducer(state, action);
}