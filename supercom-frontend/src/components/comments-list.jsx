import List from '@mui/material/List';
import ListItem from '@mui/material/ListItem';
import ListItemText from '@mui/material/ListItemText';
import moment from 'moment';
import { connect } from 'react-redux';
import { useEffect } from 'react';
import getInstance from '../api/api';
import { setComments } from '../redux/tickets/tickets.actions';

const CommentsList = ({ comments, activeTicket }) => {
  const apiInstance = getInstance();

  useEffect(() => {
    apiInstance
      .get(`/api/Tickets/${activeTicket.id}/comments`)
      .then((res) => {
        setComments(res.data);
      })
      .catch((err) => {
        alert(err);
      });
  }, [activeTicket]);

  return (
    <div className='comments-container'>
      <span>Comments</span>
      <List className='comments-list'>
        {comments.map((c, i) => {
          return (
            <ListItem className={i < comments.length - 1 ? 'not-last' : ''}>
              <ListItemText primary={c.text} secondary={moment(c.createdAt).format('DD/MM/yyyy HH:mm')} />
            </ListItem>
          );
        })}
      </List>
    </div>
  );
};

const mapDispatchToProps = (dispatch) => ({
  setComments: (comments) => {
    dispatch(setComments(comments));
  },
});

const mapStateToProps = ({ ticketsData }) => ({
  comments: ticketsData.comments,
  activeTicket: ticketsData.activeTicket,
});
export default connect(mapStateToProps, mapDispatchToProps)(CommentsList);
