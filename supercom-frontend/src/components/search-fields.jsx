import React from 'react';
import FormInput from './form-input';
import FormDatepicker from './form-datepicker';
import { statuses } from '../constants/ticket-statuses';
import moment from 'moment';

const SearchTickets = ({ search, fields, setFields }) => {
  const handleChange = (e) => {
    setFields({ ...fields, [e.target.name]: e.target.value });
  };

  return (
    <div className='search-component'>
      <div className='search-fields'>
        <FormInput label='Title' value={fields.title} onChange={handleChange} name='title' />
        <FormDatepicker
          label='From'
          selectedDate={fields.from}
          onChange={handleChange}
          name='from'
          maxDate={fields.to || moment.now()}
        />
        <FormDatepicker
          label='To'
          selectedDate={fields.to}
          onChange={handleChange}
          name='to'
          minDate={fields.from}
          maxDate={moment.now()}
        />
        <FormInput label='ID' value={fields.id} onChange={handleChange} name='id' />
        <div className='form-input'>
          <label>Status</label>
          <select className='form-select' defaultValue='' value={fields.status} onChange={handleChange} name='status'>
            <option value=''>Select Status</option>
            {statuses.map((s) => {
              return <option value={s.value}>{s.text}</option>;
            })}
          </select>
        </div>
      </div>
      <button onClick={search}>search</button>
    </div>
  );
};

export default SearchTickets;
