import List from '@mui/material/List';
import ListItem from '@mui/material/ListItem';
import ListItemText from '@mui/material/ListItemText';
import DeleteIcon from '@mui/icons-material/Delete';
import moment from 'moment';
import { connect } from 'react-redux';
import { IconButton } from '@mui/material';
import { statuses } from '../constants/ticket-statuses';
import getInstance from '../api/api';
import { setActiveTicket, setTickets } from '../redux/tickets/tickets.actions';

const TicketsList = ({ tickets, pageNumber, setPageNumber, count, pageSize, setIsNewSearch, setTickets, setActiveTicket }) => {
  const handleChange = (e) => {
    setPageNumber(e.target.value);
    setIsNewSearch(false);
  };

  const apiInstance = getInstance();

  const deleteTicket = (ticket) => {
    apiInstance
      .delete(`/api/Tickets/${ticket.id}`)
      .then((res) => {
        const deletedTicket = { ...ticket, status: statuses.find((s) => s.text === 'Deleted').value };
        const i = tickets.findIndex((t) => t.id === ticket.id);
        let newTickets = [...tickets];
        newTickets[i] = deletedTicket;
        setTickets(newTickets);
      })
      .catch((err) => {
        alert(err);
      });
  };

  return (
    <div>
      <List>
        {tickets.map((t, i) => {
          return (
            <ListItem
              className={i < tickets.length - 1 ? 'not-last' : ''}
              onClick={() => {
                setActiveTicket(t);
              }}
            >
              <ListItemText
                primary={
                  <div className='ticket-top-details'>
                    <span>{t.title}</span>
                    <span>{t.id}</span>
                  </div>
                }
                secondary={
                  <div className='ticket-details'>
                    <span>{`${t.description.substring(0, 50)}${t.description.length > 50 ? '...' : ''}`}</span>
                    <span className='date-span'>{moment(t.createdAt).format('DD/MM/yyyy HH:mm')}</span>
                  </div>
                }
                className='ticket-item'
              />
              <IconButton
                className='delete-icon'
                disabled={t.status === statuses.find((s) => s.text === 'Deleted').value}
                onClick={() => deleteTicket(t)}
              >
                <DeleteIcon />
              </IconButton>
            </ListItem>
          );
        })}
      </List>
      <div className='pagination'>
        <button onClick={() => handleChange({ target: { value: pageNumber - 1 } })} disabled={pageNumber === 1}>
          {'<'}
        </button>
        <select className='form-select' value={pageNumber} onChange={handleChange} name='pageNumber'>
          {(() => {
            const options = [];
            for (let i = 1; i <= Math.ceil(count / pageSize); i++) {
              options.push(
                <option key={i} value={i}>
                  {i}
                </option>
              );
            }
            return options;
          })()}
        </select>
        <button
          onClick={() => handleChange({ target: { value: pageNumber + 1 } })}
          disabled={pageNumber === Math.ceil(count / pageSize)}
        >
          {'>'}
        </button>
      </div>
    </div>
  );
};

const mapDispatchToProps = (dispatch) => ({
  setTickets: (tickets) => {
    dispatch(setTickets(tickets));
  },
  setActiveTicket: (ticket) => {
    dispatch(setActiveTicket(ticket));
  },
});

const mapStateToProps = ({ ticketsData }) => ({
  tickets: ticketsData.tickets,
  count: ticketsData.count,
});
export default connect(mapStateToProps, mapDispatchToProps)(TicketsList);
