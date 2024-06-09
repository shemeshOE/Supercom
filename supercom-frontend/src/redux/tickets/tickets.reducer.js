import { ticketsTypes } from './tickets.types';

const initialState = {
  tickets: [],
  activeTicket: undefined,
  comments: [],
  count: 0,
};

const getInitialState = () => {
  return initialState;
};

const ticketsReducer = (state = getInitialState(), action) => {
  switch (action.type) {
    case ticketsTypes.SET_TICKETS:
      return {
        ...state,
        tickets: [...action.payload],
      };
    case ticketsTypes.SET_ACTIVE_TICKET:
      return {
        ...state,
        activeTicket: action.payload,
      };
    case ticketsTypes.SET_COMMENTS:
      return {
        ...state,
        comments: [...action.payload],
      };
    case ticketsTypes.SET_COUNT:
      return {
        ...state,
        count: action.payload,
      };
    default:
      return state;
  }
};

export default ticketsReducer;
