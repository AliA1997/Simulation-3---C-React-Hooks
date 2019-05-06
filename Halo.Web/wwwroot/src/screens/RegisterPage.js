import React, { useReducer, useContext, useState } from 'react';
//import your context and reducer for that context.
import { UserContext, UserReducer } from '../contexts/user/userReducer';
import * as utils from '../utils';
import UserApi from '../api/users/userApi';


const Register = (props) => {
    const [registerForm, setRegisterForm] = useState({
                                                username: '',
                                                avatar: '',
                                                password: ''
                                            });
                                        
    const registerValues = useContext(UserContext);

    function handleChange(e, type) {
        e.stopPropagation();
        const form = utils.deepCopy(registerForm);
        form[type] = e.target.value;
        setRegisterForm(form);
    }

    async function register() {
        const user = await new UserApi().register(registerForm);

    }
    return (
        <div>

        </div>
    );
};

export default Register;