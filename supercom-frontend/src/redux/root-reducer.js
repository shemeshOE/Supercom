import { combineReducers } from 'redux';
import { persistReducer } from 'redux-persist';
import storage from 'redux-persist/lib/storage';
import ticketsReducer from './tickets/tickets.reducer';

console.log(ticketsReducer);

const persistRootConfig = {
  key: 'root',
  storage,
};

const rootReducer = combineReducers({
  ticketsData: ticketsReducer,
});

export default persistReducer(persistRootConfig, rootReducer);
