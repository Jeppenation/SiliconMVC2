

const compareValidator = (value, compareElement) => {
    if (value !== compareElement.value) {
        return false;
    }
    return true;
}



const textValidator = (element, minLength = 2) => {
    if (element.value.length >= minLength) {
        formErrorMessage(element, true);
    }
    else {
        formErrorMessage(element, false);
    }

};


const formErrorMessage = (element, validationResult) => {
    let spanElement = document.querySelector(`[data-valmsg-for="${element.name}"]`);


    if (validationResult) {
        element.classList.remove('input-validation-error');
        spanElement.classList.remove('field-validation-error');
        spanElement.classList.add('field-validation-valid');
        spanElement.textContent = '';
    }
    else {
        element.classList.add('input-validation-error');
        spanElement.classList.add('field-validation-error');
        spanElement.classList.remove('field-validation-valid');
        spanElement.innerHTML = element.dataset.valRequired;  //<- - This is where you would put the error message, which currently im not sure how to get from the data-valmsg-for attribute.
    }
}

const checkBoxValidator = (element) => {


    if (element.checked) {
        formErrorMessage(element, true);
    }
    else {
        formErrorMessage(element, false);
    }
}

const emailValidator = (element) => {

    const emailRegEx = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
    formErrorMessage(element, emailRegEx.test(element.value));
    console.log(element);
}

const passwordValidator = (element) => {

    if (element.dataset.ValEqualtoOther !== undefined) {
        formErrorMessage(element, compareValidator(element.value, document.getElementsByName(element.dataset.ValEqualtoOther.replace('*', 'Form')[0].value)));
    }
    else {
        const passwordRegEx = /^(?=.*[^\w\d]).{8,15}$/;
        formErrorMessage(element, passwordRegEx.test(element.value));
        console.log("test");

    }

}

let forms = document.querySelectorAll('form');
let inputs = forms[0].querySelectorAll('input');

inputs.forEach(input => {
    if (input.dataset.val === "true") {

        if (input.type === 'checkbox') {
            input.addEventListener('change', (e) => {
                checkBoxValidator(e.target);
            })
        }
        else {
            input.addEventListener('keyup', (e) => {
                switch (e.target.type) {
                    case 'text':
                        console.log('test'); 
                        textValidator(e.target);
                        break;
                    case 'email':
                        emailValidator(e.target);
                        break;
                    case 'password':
                        passwordValidator(e.target);
                        break;
                }

            })
        }

    }
})