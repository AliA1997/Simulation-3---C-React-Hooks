import React, { useReducer, useContext, useState } from 'react';
//import your context and reducer for that context.
import { UserContext, UserReducer } from '../contexts/user/userReducer';
import * as utils from '../utils';
import UserApi from '../api/users/userApi';


const LoginPage = (props) => {
    const [authForm, setAuthForm] = useState({
                                                username: '',
                                                password: ''
                                            });
                                        
    const authValues = useContext(UserContext);

    function handleChange(e, type) {
        e.stopPropagation();
        const form = utils.deepCopy(authForm);
        form[type] = e.target.value;
        setAuthForm(form);
    }

    async function login() {
        const user = await new UserApi().login(authForm);

    }
    return (
        <div>

        </div>
    );
};

export default LoginPage;