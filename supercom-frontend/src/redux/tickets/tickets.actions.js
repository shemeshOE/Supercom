import { ticketsTypes } from './tickets.types';

export const setTickets = (tickets) => ({
  type: ticketsTypes.SET_TICKETS,
  payload: tickets,
});

export const setActiveTicket = (ticket) => ({
  type: ticketsTypes.SET_ACTIVE_TICKET,
  payload: ticket,
});

export const setComments = (comments) => ({
  type: ticketsTypes.SET_COMMENTS,
  payload: comments,
});

export const setCount = (count) => ({
  type: ticketsTypes.SET_COUNT,
  payload: count,
});
