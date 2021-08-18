
console.log('新邮件检查已开启。');

const button = document.createElement('button');
button.style.display = "block";
button.style.position = "fixed";
button.style.top = "0";
button.style.left = "0";
button.style.width = "100px";
button.style.height = "20px";
button.style.zIndex = "9999";
button.textContent = '检查新邮件'

document.addEventListener('readystatechange', async (event) => {
  //console.log(`readystate: ${document.readyState}`);
  window.frames['main'].document.body.insertAdjacentElement('afterbegin', button);
  await checkMail();
  setInterval(checkMail, 1*60*1000);
});


button.addEventListener('click', async () => {
  await checkMail();
});

async function checkMail() {
  const cmd = '{"model":"mail","cmd":"list","data":{"did":"91","flag":"","ord":"timedesc","page":1,"pagecount":"20","search":false,"queryand":false}}';
  const reqtime = Math.round(Number(new Date()) / 1000).toString();
  let resp = await fetch("http://mail.hg.cn/rpc?" + reqtime, {
    method: "POST",
    credentials: 'same-origin',
    headers: {
      'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8'
    },
    body: new URLSearchParams({ "anyobj": cmd, "reqtime": reqtime, "randse": reqtime })
  });

  let j = await resp.json();
  console.log(j);

  let mailnum = j?.data?.info?.newmailnum;
  if (typeof (mailnum) != 'undefined') {
    if (mailnum > 0) {
      chrome.runtime.sendMessage('', {
        type: 'notification',
        options: {
          title: '新邮件通知',
          message: "你有"+ mailnum.toString() +"封未读邮件。",
          iconUrl: '128x128_icon.png',
          type: 'basic'
        }
      });
    }
  }
}
