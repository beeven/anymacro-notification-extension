chrome.runtime.onMessage.addListener(data => {
    if (data.type === 'notification') {
      chrome.notifications.create('anymacro_checkmail', data.options);
    }
  });

chrome.browserAction.onClicked.addListener(async (tab) => {
  let queryOptions = {url:"*://mail.hg.cn/*"};
  let [t] = await chrome.tabs.query(queryOptions);
  if(t) {
    console.log(t);
    chrome.tabs.highlight({tabs: t.index, windowId: t.windowId});
  } else {
    chrome.tabs.create({active: true, url: "http://mail.hg.cn/webmailgo.php"});
  }
  
});