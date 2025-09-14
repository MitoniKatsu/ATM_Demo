import { NavLink } from 'react-router-dom';
import Styled from '../Styled/Navbar';
const Navbar = () => {
  return (
    <Styled>
      <div className="nav-center">
        <span className="logo">ATM</span>
        <div className="nav-links">
          <NavLink className="nav-link">Accounts</NavLink>
          <NavLink className="nav-link">Actions</NavLink>
          <NavLink className="nav-link">History</NavLink>
        </div>
      </div>
    </Styled>
  );
};
export default Navbar;
