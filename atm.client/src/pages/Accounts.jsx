import { useQuery } from '@tanstack/react-query';
import http from '../util/http';
const getAccountsQuery = () => {
  return {
    queryKey: ['accounts'],
    queryFn: async () => {
      const { data } = await http.get('accounts');
      return data;
    },
  };
};

export const loader = (queryClient) => async () => {
  await queryClient.ensureQueryData(getAccountsQuery());
  return null;
};

const Accounts = () => {
  const { data: accounts } = useQuery(getAccountsQuery());

  return { accounts } ? (
    <>
      <h2>Accounts of {accounts[0].accountHolder}</h2>
      <div>
        {accounts.map((account) => (
          <div
            key={account.accountNumber}
            style={{
              display: 'flex',
              flexDirection: 'row',
              gap: '2rem',
            }}
          >
            <p>Account Number: {account.accountNumber}</p>
            <p>Balance: {account.balance.toFixed(2)}</p>
          </div>
        ))}
      </div>
    </>
  ) : (
    <div>No Accounts Found</div>
  );
};
export default Accounts;
