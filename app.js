
console.log('Greet bot!');

const button = document.createElement('button');
button.style.display = "block";
button.style.position = "fixed";
button.style.top = "0";
button.style.left = "0";
button.style.width = "100px";
button.style.height = "20px";
button.style.zIndex = "9999";
button.textContent = 'Greet me!'

document.addEventListener('readystatechange', (event)=>{
  console.log(`readystate: ${document.readyState}`);
  window.frames['main'].document.body.insertAdjacentElement('afterbegin', button);
});


button.addEventListener('click', async () => {
  const cmd = '{"model":"mail","cmd":"list","data":{"did":"91","flag":"","ord":"timedesc","page":1,"pagecount":"20","search":false,"queryand":false}}';
  reqtime = Math.round(Number(new Date())/1000)
  let resp = await fetch("http://mail.hg.cn/rpc?"+reqtime,{
    method: "POST",
    headers: {
      'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8'
    },
    body: new URLSearchParams({"anyobj":cmd, "reqtime":reqtime, "randse": reqtime})
  });
  
  j = await resp.json();
  console.log(j);

  chrome.runtime.sendMessage('', {
    type: 'notification',
    options: {
      title: 'Just wanted to notify you',
      message: j?.data?.info?.newmailnum?.toString(),
      iconUrl: '/icon.png',
      type: 'basic'
    }
  });
});