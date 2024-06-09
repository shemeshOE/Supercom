import React, { useEffect, useState } from 'react';
import FormInput from './form-input';
import { setActiveTicket, setTickets } from '../redux/tickets/tickets.actions';
import { statuses } from '../constants/ticket-statuses';
import { connect } from 'react-redux';
import getInstance from '../api/api';
import FormTextArea from './form-textarea';

const TicketData = ({ activeTicket, comments, setTickets, tickets }) => {
  const [fields, setFields] = useState({
    title: activeTicket.title,
    description: activeTicket.description,
    id: activeTicket.id,
    status: activeTicket.status,
  });
  useEffect(() => {
    setFields({
      title: activeTicket.title,
      description: activeTicket.description,
      id: activeTicket.id,
      status: activeTicket.status,
    });
  }, [activeTicket]);
  const handleChange = (e) => {
    setFields({ ...fields, [e.target.name]: e.target.value });
  };

  const apiInstance = getInstance();

  const updateTicket = () => {
    apiInstance
      .put('/api/Tickets/updateTicket', fields)
      .then((res) => {
        const ticket = { ...activeTicket, title: fields.title, description: fields.description, status: fields.status };
        const i = tickets.findIndex((t) => t.id === activeTicket.id);
        let newTickets = [...tickets];
        newTickets[i] = ticket;
        setTickets(newTickets);
        setActiveTicket(ticket);
      })
      .catch((err) => {
        alert(err);
      });
  };

  const create = () => {
    apiInstance
      .post('/api/Tickets/createTicket', { title: fields.title, description: fields.description })
      .then((res) => {})
      .catch((err) => {
        alert(err);
      });
  };

  return (
    <div className='ticket-detailed-view'>
      <div className='ticket-fields'>
        <div>
          <label>ID:</label>
          <label>{fields.id}</label>
        </div>
        <div className='editable-fields'>
          <FormInput label='Title' value={fields.title} onChange={handleChange} name='title' />
          <div className='form-input'>
            <label>Status</label>
            <select className='form-select' defaultValue='' value={fields.status} onChange={handleChange} name='status'>
              <option value='' disabled hidden>
                Select Status
              </option>
              {statuses.map((s) => {
                return <option value={s.value}>{s.text}</option>;
              })}
            </select>
          </div>
          <FormTextArea
            label='Description'
            value={fields.description}
            onChange={handleChange}
            name='description'
            isMultiline={true}
          />
        </div>
      </div>
      {fields.id ? <button onClick={updateTicket}>Update</button> : <button onClick={create}>Create</button>}
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
  activeTicket: ticketsData.activeTicket,
  comments: ticketsData.comments,
});

export default connect(mapStateToProps, mapDispatchToProps)(TicketData);
