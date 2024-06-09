import React, { useState } from 'react';
import DatePicker from 'react-datepicker';
import 'react-datepicker/dist/react-datepicker.css';

const FormDatepicker = ({ label, onChange, name, selectedDate, maxDate, minDate }) => {
  const [isOpen, setOpenDatePicker] = useState(false);
  return (
    <div className='form-input'>
      <label>{label}</label>
      <DatePicker
        name={name}
        selected={selectedDate}
        onChange={(value) => {
          onChange({ target: { name, value } });
        }}
        maxDate={maxDate}
        minDate={minDate}
        autoComplete='off'
        showMonthDropdown
        showYearDropdown
        showTimeInput
        timeFormat='HH:mm'
        dateFormat='dd/MM/yyyy HH:mm'
        dropdownMode='select'
        open={isOpen}
        onInputClick={() => setOpenDatePicker(true)}
        onClickOutside={() => {
          setOpenDatePicker(false);
        }}
        onSelect={() => {
          setOpenDatePicker(false);
        }}
      />
      <i className='datePickerIcon calendar alternate outline icon' onClick={() => setOpenDatePicker(true)}></i>
    </div>
  );
};

export default FormDatepicker;
