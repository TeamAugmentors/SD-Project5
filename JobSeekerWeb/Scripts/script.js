function map(x, in_min, in_max, out_min, out_max) {
  return (x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
}
if (document.URL.includes("/Team/Member")) {
  // =================================================
  // team page Animation
  // =================================================

  // vanilla-tilt 
  VanillaTilt.init(document.querySelectorAll(".default-card"), {
    max: 25,
    speed: 400,
    glare: true,
    "max-glare": 1,
  });

  new fullpage('#team-fullpage', {
    navigation: true
  });

  let i = 0;
  let text = 'Meet the team.';
  let textSpeed = 100;

  function typeWriter() {
    if (i < text.length) {
      document.querySelector("#team--hero-header").innerHTML += text.charAt(i++);
      setTimeout(typeWriter, textSpeed);
    }
  }
  typeWriter();
}

else if (document.URL.includes("User/SignIn")) {
  // =====================Sign inpage back button===============================
  const signInBackButton = document.querySelector(".signin-page .arrow-left");
  signInBackButton.addEventListener('click', () => {
    history.back();
  });
}

else if (document.URL.includes("User/SignUp")) {
  // =====================Sign inSign up page back button===============================
  const signInBackButton = document.querySelector(".signup-page .arrow-left");
  signInBackButton.addEventListener('click', () => {
    history.back();
  });
}
else if (document.URL.includes("Explore/Jobs")) {
  const catagoryIconTriangle = document.querySelector(".catagory-div .icon-triangle");
  const catagoryItems = document.querySelector(".explore-container .left .choose-catagory");
  const budgetIconTriangle = document.querySelector(".budget-div .icon-triangle");
  const budgetContainer = document.querySelector(".budget-div .content");
  const jobCardContainer = document.querySelector(".explore-container .right .job-card-container");
  const thumbsContainer = document.querySelector(".amount-slider .thumbs");
  const leftThumb = document.querySelector(".amount-slider .left-thumb");
  const rightThumb = document.querySelector(".amount-slider .right-thumb");
  const selectedTrack = document.querySelector(".amount-slider .track-selected");
  const tkMin = document.querySelector(".slider-container .tk-min");
  const tkMax = document.querySelector(".slider-container .tk-max");
  const inputTkMin = document.querySelector(".input-amount .input-tk-min");
  const inputTkMax = document.querySelector(".input-amount .input-tk-max");
  console.log(inputTkMin);
  console.log(inputTkMax);
  let isLeftThumb = false;
  let isRightThumb = false;
  let thumbposLeft = 0;
  let thumbposRight = 100;

  function initSliders() {
    leftThumb.style.left = `${thumbposLeft}%`;
    selectedTrack.style.left = `${thumbposLeft}%`;
    rightThumb.style.left = `${thumbposRight}%`;
    selectedTrack.style.right = `${100 - thumbposRight}%`;
    inputTkMin.value = parseInt(map(thumbposLeft, 0, 100, 0, 50000));
    inputTkMax.value = parseInt(map(thumbposRight, 0, 100, 0, 50000));
    tkMin.innerText = inputTkMin.value / 1000 + 'k';
    tkMax.innerText = inputTkMax.value / 1000 + 'k';
  }

  initSliders();

  function mouseDownHandler(e) {
    console.log("Mouse Down");
    if (e.target == leftThumb) {
      isLeftThumb = true;
    } else if (e.target == rightThumb) {
      isRightThumb = true;
    }
    document.addEventListener('mousemove', mouseMoveHandler);
    document.addEventListener('mouseup', mouseUpHandler);
  }

  function mouseMoveHandler(e) {
    // prnt("Mouse move");
    if (isLeftThumb) {
      let dx = e.clientX;
      let rect = thumbsContainer.getBoundingClientRect();
      let thumbsContainerLeft = rect.left;
      let thumbContainerWidth = rect.width;
      thumbposLeft = (dx - thumbsContainerLeft) / thumbContainerWidth * 100;
      if (thumbposLeft > thumbposRight) {
        thumbposLeft = thumbposRight;
      }
      else if (thumbposLeft < 0) {
        thumbposLeft = 0;
      }
      leftThumb.style.left = `${thumbposLeft}%`;
      selectedTrack.style.left = `${thumbposLeft}%`;
      inputTkMin.value = parseInt(map(thumbposLeft, 0, 100, 0, 50000));
      tkMin.innerText = parseInt(inputTkMin.value / 1000) > 0 ? parseInt(inputTkMin.value / 1000) + 'k' : 0;

    } else if (rightThumb) {
      let dx = e.clientX;
      let rect = thumbsContainer.getBoundingClientRect();
      let thumbsContainerLeft = rect.left;
      let thumbContainerWidth = rect.width;
      thumbposRight = (dx - thumbsContainerLeft) / thumbContainerWidth * 100;
      if (thumbposRight < thumbposLeft) {
        thumbposRight = thumbposLeft;
      }
      else if (thumbposRight > 100) {
        thumbposRight = 100;
      }
      rightThumb.style.left = `${thumbposRight}%`;
      selectedTrack.style.right = `${100 - thumbposRight}%`;
      inputTkMax.value = parseInt(map(thumbposRight, 0, 100, 0, 50000));
      tkMax.innerText = parseInt(inputTkMax.value / 1000) > 0 ? parseInt(inputTkMax.value / 1000) + 'k' : 0;
    }
  }
  function mouseUpHandler() {
    isLeftThumb = false;
    isRightThumb = false;
    document.removeEventListener('mousemove', mouseMoveHandler);
    document.removeEventListener('mouseup', mouseUpHandler);
  };

  leftThumb.addEventListener('mousedown', mouseDownHandler);
  leftThumb.addEventListener('mouseup', mouseMoveHandler);

  rightThumb.addEventListener('mousedown', mouseDownHandler);
  rightThumb.addEventListener('mouseup', mouseMoveHandler);

  inputTkMin.addEventListener('change', () => {
    let minTk = parseInt(inputTkMin.value);
    let maxTk = parseInt(inputTkMax.value);
    if (minTk > maxTk) {
      minTk = maxTk;
    }
    minTk = Math.min(minTk, 50000);
    inputTkMin.value = minTk;
    thumbposLeft = parseInt(map(minTk, 0, 50000, 0, 100));
    leftThumb.style.left = `${thumbposLeft}%`;
    selectedTrack.style.left = `${thumbposLeft}%`;
    let tkMinText = parseInt(inputTkMin.value / 1000)
    tkMin.innerText = tkMinText > 0 ? tkMinText + 'k' : 0;
  });
  inputTkMax.addEventListener('change', () => {
    let minTk = parseInt(inputTkMin.value);
    let maxTk = parseInt(inputTkMax.value);
    if (maxTk < minTk) {
      maxTk = minTk;
    }
    maxTk = Math.min(maxTk, 50000);
    inputTkMax.value = maxTk;
    thumbposRight = parseInt(map(maxTk, 0, 50000, 0, 100));
    rightThumb.style.left = `${thumbposRight}%`;
    // console.log(thumbposRight);
    selectedTrack.style.right = `${100 - thumbposRight}%`;
    tkMaxText = parseInt(inputTkMax.value / 1000);
    tkMax.innerText = tkMaxText > 0 ? tkMaxText + 'k' : 0;
  });

  isToggleCatagory = false;
  isToggleBudget = false;

  // ------------------This is for setting the opacity and height after loading the page----------------
  budgetContainer.style.maxHeight = budgetContainer.scrollHeight + "px";;
  budgetContainer.style.opacity = '1';
  catagoryItems.style.maxHeight = catagoryItems.scrollHeight + "px";
  catagoryItems.style.opacity = '1';
  catagoryItems.style.marginBottom = '2rem';

  budgetIconTriangle.addEventListener('click', () => {
    if (!isToggleBudget) {
      budgetIconTriangle.style.transform = 'rotate(-90deg)';
      budgetContainer.style.maxHeight = '0';
      budgetContainer.style.opacity = '0';
      isToggleBudget = true;
    } else {
      budgetIconTriangle.style.transform = 'rotate(0deg)';
      budgetContainer.style.maxHeight = budgetContainer.scrollHeight + "px";
      budgetContainer.style.opacity = '1';
      isToggleBudget = false;
    }
  })

  catagoryIconTriangle.addEventListener("click", () => {
    if (!isToggleCatagory) {
      catagoryIconTriangle.style.transform = 'rotate(-90deg)';
      catagoryItems.style.maxHeight = '0';
      catagoryItems.style.opacity = '0';
      isToggleCatagory = true;
    } else {
      catagoryIconTriangle.style.transform = 'rotate(0deg)';
      catagoryItems.style.maxHeight = catagoryItems.scrollHeight + "px";
      catagoryItems.style.opacity = '1';
      isToggleCatagory = false;
    }
  })
} else if (document.URL.includes("/Profile/Edit")) {
  const changePictureBtn = document.querySelector('.change-picture-btn');
  const avaterImage = document.querySelector('.avatar-img');
  const chooseImage = document.querySelector('.choose-image');

  const log = (x) => console.log(x);
  changePictureBtn.addEventListener('click', (e) => {
    e.preventDefault();
    chooseImage.click();
  })

  chooseImage.addEventListener('change', function () {
    console.log("I am here");
    const file = this.files[0];
    if (file) {
      const reader = new FileReader();
      reader.onload = () => {
        const result = reader.result;
        avaterImage.src = result;
      };
      reader.readAsDataURL(file);
    }
  });
}