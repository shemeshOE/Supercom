import { applyMiddleware } from 'redux';
import { persistStore } from 'redux-persist';
import logger from 'redux-logger';
import { composeWithDevTools } from '@redux-devtools/extension';

import rootReducer from './root-reducer';

import { configureStore } from '@reduxjs/toolkit';

const middlewares = [logger];

export const store = configureStore({ reducer: rootReducer }, composeWithDevTools(applyMiddleware(...middlewares)));

export const persistor = persistStore(store);
