<?php

//自在观喵 HTTP 消息中转接口

error_reporting("E_ALL & ~E_NOTICE & ~E_STRICT & ~E_DEPRECATED");

$api_secret		= ''; //务必设置，客户端不接受空值
$data_folder	= 'wn_data';

$action		= strtolower(trim($_POST['action']));
$cday_file	= dirname(__FILE__).'/'.$data_folder.'/'.date('Ymd').'.php';

create_datafile($data_folder, $cday_file);

$request_secret = trim($_POST['key']);
if($request_secret !== $api_secret) exit();

switch($action) {
	
	//提交消息
	case 'update':
		$new_ln = trim($_POST['text']);
		$new_ln = preg_replace('/^.?$\n/m', '', $new_ln);
		if(empty($new_ln)) break;
		file_put_contents($cday_file, "\n".TIME().'|0|'.$new_ln, FILE_APPEND);
		echo("ok");
		break;
	
	//获取未读消息
	case 'fetch':
		//初始化输出数组
		$output = array();
		//将当日数据文件读入 $data 数组，并将顺序反转，以从尾部开始读取
		$data = file($cday_file);
		$data = array_reverse($data);
		//数据文件小于 2 行的话直接跳出
		if(sizeof($data) < 2) break;
		//依次读取没调数据
		for($n = 0; $n < sizeof($data); $n++) {
			//分解行数据
			$ln_array = explode('|', $data[$n]);
			//如果分解后不是 3 个元素则跳过
			if(sizeof($ln_array) <> 3) continue;
			//如果第 2 个元素是 0 表示是未读消息，
			//写入输出的同时，将 $data 对应行第 2 元素改为 1 表示已读
			if($ln_array[1] === '0') {
				$output[] = $ln_array[0].'|'.$ln_array[2];
				$data[$n] = $ln_array[0].'|1|'.$ln_array[2];
			}
			//读到第 2 个元素为 1 时表示遇到上一条已读消息，停止读取
			if($ln_array[1] === '1') break;
		}
		//将 $data 顺序重新反转，并覆写数据文件
		$data = array_reverse($data);
		file_put_contents($cday_file, $data);
		//如果有未读消息，输出给客户端
		foreach($output as $ln) echo("\n".$ln);
		break;
	
	default: break;
}

function create_datafile($data_folder, $cday_file) {
	//如果当日数据文件不存在，则创建新文件
	$data_folder = dirname(__FILE__).'/'.$data_folder.'/';
	if(file_exists($data_folder) === FALSE) mkdir($data_folder);
	if(file_exists($cday_file) === FALSE) {
		$f = fopen($cday_file, 'w');
		fwrite($f, '<?php exit();?>');
		fclose($f);
	}
}

?>