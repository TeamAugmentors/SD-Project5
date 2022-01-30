
let select = document.getElementById('createJobSelect')
let allChips = Array.from(document.getElementsByClassName('chip'))

select.style.color = "#c2c2c2"

select.addEventListener('change', (e) => {
    if (e.target.value === 'Select Category --')
        select.style.color = "#c2c2c2"
    else
        select.style.color = "#000000"
})

const submitForm = () => {
    let form = document.getElementById('createJobForm')
    if (!(select.value === 'Select Category --')) {
        addDataToForm(form, {
            'details': document.getElementById('textarea').value,
            'negotiable': Number(allChips.find(e => e.getAttribute("chip-selected") === "true").innerHTML === 'Yes'),
        })
        form.submit()
    } else {
    }
}


const chipEventListener = (event) => {
    allChips.forEach(e => {
        e.setAttribute("chip-selected", e === event.currentTarget)
    })
}

allChips.forEach(e => {
    e.addEventListener('click', chipEventListener)
})


function addDataToForm(form, data) {
    if (typeof form === 'string') {
        if (form[0] === '#') form = form.slice(1);
        form = document.getElementById(form);
    }

    var keys = Object.keys(data);
    var name;
    var value;
    var input;

    for (var i = 0; i < keys.length; i++) {
        name = keys[i];
        // removing the inputs with the name if already exists [overide]
        // console.log(form);
        Array.prototype.forEach.call(form.elements, function (inpt) {
            if (inpt.name === name) {
                inpt.parentNode.removeChild(inpt);
            }
        });

        value = data[name];
        input = document.createElement('input');
        input.setAttribute('name', name);
        input.setAttribute('value', value);
        input.setAttribute('type', 'hidden');

        form.appendChild(input);
    }

    return form;
}