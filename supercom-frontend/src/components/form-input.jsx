const FormInput = ({ label, onChange, value, name, isMultiline = false }) => {
  return (
    <div className='form-input'>
      <label>{label}</label>
      <input value={value} onChange={onChange} name={name} autoComplete='off' multiple={isMultiline} />
    </div>
  );
};

export default FormInput;
