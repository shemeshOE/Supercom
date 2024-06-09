import { useEffect, useState } from 'react';
import './App.css';
import SearchFields from './components/search-fields';
import TicketsList from './components/tickets-list';
import { setCount, setTickets } from './redux/tickets/tickets.actions';
import { connect } from 'react-redux';
import moment from 'moment';
import getInstance from './api/api';
import TicketData from './components/ticket-data';
import CommentsList from './components/comments-list';

const App = ({ setTickets, setCount, activeTicket }) => {
  const [isNewSearch, setIsNewSearch] = useState(true);
  const [pageNumber, setPageNumber] = useState(1);
  const pageSize = 5;
  const [fields, setFields] = useState({
    title: '',
    from: '',
    to: '',
    id: '',
    status: '',
  });

  const apiInstance = getInstance();

  const search = (isPageChange = true) => {
    let searchString = '';
    if (fields.id) {
      searchString += `id=${fields.id}&`;
    }
    if (fields.title) {
      searchString += `title=${fields.title}&`;
    }
    if (fields.from) {
      searchString += `createdAtFrom=${moment.utc(fields.from).format('yyyy-MM-DDTHH:mm')}&`;
    }
    if (fields.to) {
      searchString += `createdAtTo=${moment(fields.to)}&`;
    }
    if (fields.status) {
      searchString += `status=${fields.status}&`;
    }
    searchString += `pageNumber=${isPageChange ? pageNumber : 1}&pageSize=${pageSize}`;
    apiInstance.get(`/api/Tickets/search?${searchString}`).then((res) => {
      setTickets(res.data.tickets);
      setCount(res.data.count);
    });
    if (!isPageChange) {
      setPageNumber(1);
      setIsNewSearch(true);
    }
  };

  useEffect(() => {
    if (!isNewSearch) {
      search();
    }
  }, [pageNumber]);

  return (
    <div className='App'>
      <span className='system-title'>Ticket System</span>
      <SearchFields
        pageNumber={pageNumber}
        pageSize={pageSize}
        search={() => search(false)}
        fields={fields}
        setFields={setFields}
      />
      <div className='ticket-data'>
        <TicketsList
          pageNumber={pageNumber}
          pageSize={pageSize}
          setPageNumber={setPageNumber}
          search={search}
          setIsNewSearch={setIsNewSearch}
        />
        {activeTicket && <TicketData />}
        {activeTicket && <CommentsList />}
      </div>
    </div>
  );
};

const mapDispatchToProps = (dispatch) => ({
  setTickets: (tickets) => {
    dispatch(setTickets(tickets));
  },
  setCount: (count) => {
    dispatch(setCount(count));
  },
});

const mapStateToProps = ({ ticketsData }) => ({
  activeTicket: ticketsData.activeTicket,
});

export default connect(mapStateToProps, mapDispatchToProps)(App);
