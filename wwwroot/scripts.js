export function checkMail() {
    const cmd = '{"model":"mail","cmd":"list","data":{"did":"91","flag":"","ord":"timedesc","page":1,"pagecount":"20","search":false,"queryand":false}}';
    const reqtime = Math.round(Number(new Date()) / 1000).toString();
    return fetch("http://mail.hg.cn/rpc?" + reqtime, {
        method: "POST",
        credentials: 'include',
        headers: {
            'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8'
        },
        body: new URLSearchParams({ "anyobj": cmd, "reqtime": reqtime, "randse": reqtime })
    }).then((resp)=>resp.text());
}