 public OperationResult GetFilesMedikit(string _UserFtp, string _PasswordFtp, string _User, string _PathTemporal, string _Folder, string _TempBackup, string _Temperrors)
        {
            RepositoryPadronSICAS _RepoSicas = new RepositoryPadronSICAS();
            OperationResult _Response = new OperationResult();
            ListFilesFtpResponseDTO _ListNames = new ListFilesFtpResponseDTO();
            RepositoryApiSase _Repo = new RepositoryApiSase();
            List<FileFTPDTO> _NamesFileList = new List<FileFTPDTO>();
            CoreApiSase _CoreApiSase = new CoreApiSase(this._Logger);
            MedikitFTPFile _FileMedikit = new MedikitFTPFile();
            string _TempPath = _PathTemporal;
            string _FullPath = string.Empty;
            ReadFile _Excel = new ReadFile();
            bool _exist = false;
            try
            {
                _ListNames = GetFileListFromFTP(_UserFtp, _PasswordFtp, _Folder);
                if (_ListNames.Files.Count > 0)
                {
                    if (!Directory.Exists(_TempBackup))
                    {
                        Directory.CreateDirectory(_TempBackup);
                    }
                    if (!Directory.Exists(_Temperrors))
                    {
                        Directory.CreateDirectory(_Temperrors);
                    }
                    _NamesFileList = GetListFileNames(_ListNames.Files);
                    foreach (var _File in _NamesFileList)
                    {
                        _Response = DownloadFile(_File.Nombre.ToString(), _UserFtp, _PasswordFtp, _PathTemporal, _Folder);
                    }
                    DirectoryInfo di = new DirectoryInfo(_TempPath);
                    FileInfo[] _ListFileInfo = di.GetFiles("*.csv");
                    if (_ListFileInfo != null)
                    {
                        foreach (FileInfo file in _ListFileInfo)
                        {
                            _exist = _RepoSicas.ExistRegister(file.Name);
                            if (!_exist)
                            {
                                _FileMedikit.NombreArchivo = file.Name;
                                _FileMedikit.FechaProceso = DateTime.Now;
                                _FileMedikit.UserInsert = _User.Trim();
                                _Repo.AddSase(_FileMedikit);
                            }
                            else
                            {
                                DeleteFileDirectory(_TempPath, "*.csv");
                                DeleteFileDirectory(_TempBackup, "*.csv");
                                DeleteFileDirectory(_Temperrors, "*.csv");
                                _Response.SetStatusCode(OperationResult.StatusCodesEnum.NOT_FOUND);
                                _Response.AddException(new Exception("El archivo ya existe favor de validar. "));
                                return _Response;
                            }
                        }
                        foreach (FileInfo file in _ListFileInfo)
                        {
                            string p = _TempPath + "\\" + file.Name;
                            MedikitFTPFile _NameFile = _RepoSicas.GetFileMedikitByName(file.Name);
                            if (_NameFile != null)
                            {
                                int _Id = _NameFile.Id;
                                DataTable dt = this.ReadFileCSVMedikit(p);
                                dt.Rows.RemoveAt(0);
                                MedikitFtpFileDetail dtl = new MedikitFtpFileDetail();
                                foreach (DataRow x in dt.Rows)
                                {
                                    dtl.IdFile = _Id;
                                    dtl.Nur = !string.IsNullOrEmpty(x.ItemArray[0].ToString()) ? ReplaceCharactersinStringDataType(x.ItemArray[0].ToString()) : string.Empty;
                                    dtl.Paciente = !string.IsNullOrEmpty(x.ItemArray[1].ToString()) ? ReplaceCharactersinStringDataType(x.ItemArray[1].ToString()) : string.Empty;
                                    dtl.Doctor = !string.IsNullOrEmpty(x.ItemArray[2].ToString()) ? ReplaceCharactersinStringDataType(x.ItemArray[2].ToString()) : string.Empty;
                                    dtl.Nombre = !string.IsNullOrEmpty(x.ItemArray[3].ToString()) ? ReplaceCharactersinStringDataType(x.ItemArray[3].ToString()) : string.Empty;
                                    dtl.Dispensacion_de_medicamentos = !string.IsNullOrEmpty(x.ItemArray[4].ToString()) ? ReplaceCharactersinStringDataType(x.ItemArray[4].ToString()) : string.Empty;
                                    dtl.Fecha_de_creacion = ConvertDateTimeIso(x.ItemArray[5].ToString().Replace(";", ""));
                                    dtl.Creado_por = !string.IsNullOrEmpty(x.ItemArray[6].ToString()) ? ReplaceCharactersinStringDataType(x.ItemArray[6].ToString()) : string.Empty;
                                    dtl.Ultima_modificacion = ConvertDateTimeIso(x.ItemArray[7].ToString().Replace(";", ""));
                                    dtl.Ultima_modificacion_por = !string.IsNullOrEmpty(x.ItemArray[8].ToString()) ? ReplaceCharactersinStringDataType(x.ItemArray[8].ToString()) : string.Empty;
                                    dtl.Estatus = !string.IsNullOrEmpty(x.ItemArray[9].ToString()) ? ReplaceCharactersinStringDataType(x.ItemArray[9].ToString()) : string.Empty;
                                    dtl.Nombre_Medicacion = !string.IsNullOrEmpty(x.ItemArray[10].ToString()) ? ReplaceCharactersinStringDataType(x.ItemArray[10].ToString()) : string.Empty;
                                    dtl.Receta_relacionada = !string.IsNullOrEmpty(x.ItemArray[11].ToString()) ? ReplaceCharactersinStringDataType(x.ItemArray[11].ToString()) : string.Empty;
                                    dtl.Cantidad = !string.IsNullOrEmpty(x.ItemArray[12].ToString()) ? int.Parse(x.ItemArray[12].ToString()) : 0;
                                    dtl.Fecha_Dispensada = ConvertDateTimeIso(x.ItemArray[13].ToString().Replace(";", ""));
                                    dtl.Ticket = !string.IsNullOrEmpty(x.ItemArray[14].ToString()) ? x.ItemArray[14].ToString() : string.Empty;
                                    dtl.Precio_Venta_Unitario_AC = !string.IsNullOrEmpty(x.ItemArray[15].ToString()) ? Convert.ToDecimal(x.ItemArray[15].ToString()) : 0;
                                    dtl.DescuentoPorcentaje = !string.IsNullOrEmpty(x.ItemArray[16].ToString()) ? Convert.ToDecimal(x.ItemArray[16].ToString()) : 0;
                                    dtl.Descuento_Monto_Unitario = !string.IsNullOrEmpty(x.ItemArray[17].ToString()) ? Convert.ToDecimal(x.ItemArray[17].ToString()) : 0;
                                    dtl.Descuento_Monto_por_cantidad_de_piezas_surtidas = !string.IsNullOrEmpty(x.ItemArray[18].ToString()) ? Convert.ToDecimal(x.ItemArray[18].ToString()) : 0;
                                    dtl.Precio_MAC_Unitario = !string.IsNullOrEmpty(x.ItemArray[19].ToString()) ? Convert.ToDecimal(x.ItemArray[19].ToString()) : 0;
                                    dtl.Precio_MAC_Total = !string.IsNullOrEmpty(x.ItemArray[20].ToString()) ? Convert.ToDecimal(x.ItemArray[20].ToString()) : 0;
                                    dtl.IVAPorcentaje = !string.IsNullOrEmpty(x.ItemArray[21].ToString()) ? Convert.ToDecimal(x.ItemArray[21].ToString()) : 0;
                                    dtl.IVA_identificador_por_medicamento = !string.IsNullOrEmpty(x.ItemArray[22].ToString()) ? Convert.ToDecimal(x.ItemArray[22].ToString()) : 0;
                                    dtl.CopagoPorcentaje = !string.IsNullOrEmpty(x.ItemArray[23].ToString()) ? Convert.ToDecimal(x.ItemArray[23].ToString()) : 0;
                                    dtl.Monto_Copago_Unitario = !string.IsNullOrEmpty(x.ItemArray[24].ToString()) ? Convert.ToDecimal(x.ItemArray[24].ToString()) : 0;
                                    dtl.Monto_Copago_Total = !string.IsNullOrEmpty(x.ItemArray[25].ToString()) ? Convert.ToDecimal(x.ItemArray[25].ToString()) : 0;
                                    dtl.Importe_Despues_Copago_Unitario = !string.IsNullOrEmpty(x.ItemArray[26].ToString()) ? Convert.ToDecimal(x.ItemArray[26].ToString()) : 0;
                                    dtl.Importe_Despues_Copago_Total = !string.IsNullOrEmpty(x.ItemArray[27].ToString()) ? Convert.ToDecimal(x.ItemArray[27].ToString()) : 0;
                                    dtl.Monto_Unitario_IVA = !string.IsNullOrEmpty(x.ItemArray[28].ToString()) ? Convert.ToDecimal(x.ItemArray[28].ToString()) : 0;
                                    dtl.Monto_Total_IVA = !string.IsNullOrEmpty(x.ItemArray[29].ToString()) ? ReemplazarCaracteresenDatosDecimal(x.ItemArray[29].ToString()) : 0;
                                    dtl.Total = !string.IsNullOrEmpty(x.ItemArray[30].ToString()) ? Convert.ToDecimal(x.ItemArray[30].ToString()) : 0;
                                    dtl.Numero_de_Sucursal = !string.IsNullOrEmpty(x.ItemArray[31].ToString()) ? int.Parse(x.ItemArray[31].ToString()) : 0;
                                    dtl.EAN = !string.IsNullOrEmpty(x.ItemArray[32].ToString()) ? ReplaceCharactersinStringDataType(x.ItemArray[32].ToString()) : string.Empty;
                                    dtl.Nombre_de_Sucursal = !string.IsNullOrEmpty(x.ItemArray[33].ToString()) ? ReplaceCharactersinStringDataType(x.ItemArray[33].ToString()) : string.Empty;
                                    dtl.Precio_Bruto_Unitario_POS = !string.IsNullOrEmpty(x.ItemArray[34].ToString()) ? Convert.ToDecimal(x.ItemArray[34].ToString()) : 0;
                                    dtl.Precio_Bruto_POS = !string.IsNullOrEmpty(x.ItemArray[35].ToString()) ? Convert.ToDecimal(x.ItemArray[35].ToString()) : 0;
                                    dtl.Nombre_de_la_cuenta_del_dispensador = !string.IsNullOrEmpty(x.ItemArray[36].ToString()) ? ReplaceCharactersinStringDataType(x.ItemArray[36].ToString()) : string.Empty;
                                    if (dtl.Nur == "" || dtl.Total == 0 || dtl.EAN == "" || dtl.Cantidad == 0)
                                    {
                                        dtl.Procesado = Estatus.Inactivo;
                                    }
                                    else
                                    {
                                        dtl.Procesado = Estatus.Activo;
                                    }
                                    _Repo.AddSase(dtl);
                                }
                            }
                            else
                            {
                                _Response.SetStatusCode(OperationResult.StatusCodesEnum.NOT_FOUND);
                                _Response.AddException(new Exception("No se encontrarón resultados"));
                                return _Response;
                            }
                        }
                        foreach (FileInfo file in _ListFileInfo)
                        {
                            List<MedikitFtpFileDetail> _ListErrores = new List<MedikitFtpFileDetail>();
                            List<MedikitFtpFileDetail> _ListBackup = new List<MedikitFtpFileDetail>();
                            var _ListData = _RepoSicas.GetListFilesMedikit(file.Name);
                            foreach (var item in _ListData)
                            {
                                if (item.Procesado == Estatus.Activo)
                                {
                                    _ListBackup.Add(new MedikitFtpFileDetail()
                                    {
                                        Nur = item.Nur,
                                        Paciente = item.Paciente,
                                        Doctor = item.Doctor,
                                        Nombre = item.Nombre,
                                        Dispensacion_de_medicamentos = item.Dispensacion_de_medicamentos,
                                        Fecha_de_creacion = item.Fecha_de_creacion,
                                        Creado_por = item.Creado_por,
                                        Ultima_modificacion = item.Ultima_modificacion,
                                        Ultima_modificacion_por = item.Ultima_modificacion_por,
                                        Estatus = item.Estatus,
                                        Nombre_Medicacion = item.Nombre_Medicacion,
                                        Receta_relacionada = item.Receta_relacionada,
                                        Cantidad = item.Cantidad,
                                        Fecha_Dispensada = item.Fecha_Dispensada,
                                        Ticket = item.Ticket,
                                        Precio_Venta_Unitario_AC = item.Precio_Venta_Unitario_AC,
                                        DescuentoPorcentaje = item.DescuentoPorcentaje,
                                        Descuento_Monto_Unitario = item.Descuento_Monto_Unitario,
                                        Descuento_Monto_por_cantidad_de_piezas_surtidas = item.Descuento_Monto_por_cantidad_de_piezas_surtidas,
                                        Precio_MAC_Unitario = item.Precio_MAC_Unitario,
                                        Precio_MAC_Total = item.Precio_MAC_Total,
                                        IVAPorcentaje = item.IVAPorcentaje,
                                        IVA_identificador_por_medicamento = item.IVA_identificador_por_medicamento,
                                        CopagoPorcentaje = item.CopagoPorcentaje,
                                        Monto_Copago_Unitario = item.Monto_Copago_Unitario,
                                        Monto_Copago_Total = item.Monto_Copago_Total,
                                        Importe_Despues_Copago_Unitario = item.Importe_Despues_Copago_Unitario,
                                        Importe_Despues_Copago_Total = item.Importe_Despues_Copago_Total,
                                        Monto_Unitario_IVA = item.Monto_Unitario_IVA,
                                        Monto_Total_IVA = item.Monto_Total_IVA,
                                        Total = item.Total,
                                        Numero_de_Sucursal = item.Numero_de_Sucursal,
                                        EAN = item.EAN,
                                        Nombre_de_Sucursal = item.Nombre_de_Sucursal,
                                        Precio_Bruto_Unitario_POS = item.Precio_Bruto_Unitario_POS,
                                        Precio_Bruto_POS = item.Precio_Bruto_POS,
                                        Nombre_de_la_cuenta_del_dispensador = item.Nombre_de_la_cuenta_del_dispensador
                                    });
                                }
                                else
                                {
                                    _ListErrores.Add(new MedikitFtpFileDetail()
                                    {
                                        Nur = item.Nur,
                                        Paciente = item.Paciente,
                                        Doctor = item.Doctor,
                                        Nombre = item.Nombre,
                                        Dispensacion_de_medicamentos = item.Dispensacion_de_medicamentos,
                                        Fecha_de_creacion = item.Fecha_de_creacion,
                                        Creado_por = item.Creado_por,
                                        Ultima_modificacion = item.Ultima_modificacion,
                                        Ultima_modificacion_por = item.Ultima_modificacion_por,
                                        Estatus = item.Estatus,
                                        Nombre_Medicacion = item.Nombre_Medicacion,
                                        Receta_relacionada = item.Receta_relacionada,
                                        Cantidad = item.Cantidad,
                                        Fecha_Dispensada = item.Fecha_Dispensada,
                                        Ticket = item.Ticket,
                                        Precio_Venta_Unitario_AC = item.Precio_Venta_Unitario_AC,
                                        DescuentoPorcentaje = item.DescuentoPorcentaje,
                                        Descuento_Monto_Unitario = item.Descuento_Monto_Unitario,
                                        Descuento_Monto_por_cantidad_de_piezas_surtidas = item.Descuento_Monto_por_cantidad_de_piezas_surtidas,
                                        Precio_MAC_Unitario = item.Precio_MAC_Unitario,
                                        Precio_MAC_Total = item.Precio_MAC_Total,
                                        IVAPorcentaje = item.IVAPorcentaje,
                                        IVA_identificador_por_medicamento = item.IVA_identificador_por_medicamento,
                                        CopagoPorcentaje = item.CopagoPorcentaje,
                                        Monto_Copago_Unitario = item.Monto_Copago_Unitario,
                                        Monto_Copago_Total = item.Monto_Copago_Total,
                                        Importe_Despues_Copago_Unitario = item.Importe_Despues_Copago_Unitario,
                                        Importe_Despues_Copago_Total = item.Importe_Despues_Copago_Total,
                                        Monto_Unitario_IVA = item.Monto_Unitario_IVA,
                                        Monto_Total_IVA = item.Monto_Total_IVA,
                                        Total = item.Total,
                                        Numero_de_Sucursal = item.Numero_de_Sucursal,
                                        EAN = item.EAN,
                                        Nombre_de_Sucursal = item.Nombre_de_Sucursal,
                                        Precio_Bruto_Unitario_POS = item.Precio_Bruto_Unitario_POS,
                                        Precio_Bruto_POS = item.Precio_Bruto_POS,
                                        Nombre_de_la_cuenta_del_dispensador = item.Nombre_de_la_cuenta_del_dispensador
                                    });
                                }
                            }
                            if (_ListBackup.Count > 0)
                            {

                                string _Text = string.Empty;
                                string header = "NUR|Paciente|Doctor|Nombre|Dispensacion_de_medicamentos" +
                                          "|Fecha_de_creacion|Creado_por|Ultima_modificacion|Ultima_modificacion_por|Estatus" +
                                          "|Nombre_Medicacion|Receta_relacionada|Cantidad|Fecha_Dispensada|Ticket|Precio_Venta_Unitario_(AC)" +
                                          "|Descuento%|Descuento_Monto_Unitario|Descuento_Monto_por_cantidad_de_piezas_surtidas" +
                                          "|Precio_MAC_Unitario|Precio_MAC_Total|IVA%|IVA_identificador_por_medicamento|Copago%" +
                                          "|Monto_Copago_Unitario|Monto_Copago_Total|Importe_Despues_Copago_Unitario" +
                                          "|Importe_Despues_Copago_Total|Monto_Unitario_IVA|Monto_Total_IVA|Total|Numero_de_Sucursal" +
                                          "|EAN|Nombre_de_Sucursal|Precio_Bruto_Unitario_POS|Precio_Bruto_POS|Nombre_de_la_cuenta_del_dispensador" + Environment.NewLine;
                                _ListBackup.ForEach(x =>
                                                            _Text = string.Concat(_Text,
                                                                    x.Nur, "|",
                                                                    x.Paciente, "|",
                                                                    x.Doctor, "|",
                                                                    x.Nombre, "|",
                                                                    x.Dispensacion_de_medicamentos, "|",
                                                                    x.Fecha_de_creacion, "|",
                                                                    x.Creado_por, "|",
                                                                    x.Ultima_modificacion, "|",
                                                                    x.Ultima_modificacion_por, "|",
                                                                    x.Estatus, "|",
                                                                    x.Nombre_Medicacion, "|",
                                                                    x.Receta_relacionada, "|",
                                                                    x.Cantidad, "|",
                                                                    x.Fecha_Dispensada, "|",
                                                                    x.Ticket, "|",
                                                                    x.Precio_Venta_Unitario_AC, "|",
                                                                    x.DescuentoPorcentaje, "|",
                                                                    x.Descuento_Monto_Unitario, "|",
                                                                    x.Descuento_Monto_por_cantidad_de_piezas_surtidas, "|",
                                                                    x.Precio_MAC_Unitario, "|",
                                                                    x.Precio_MAC_Total, "|",
                                                                    x.IVAPorcentaje, "|",
                                                                    x.IVA_identificador_por_medicamento, "|",
                                                                    x.CopagoPorcentaje, "|",
                                                                    x.Monto_Copago_Unitario, "|",
                                                                    x.Monto_Copago_Total, "|",
                                                                    x.Importe_Despues_Copago_Unitario, "|",
                                                                    x.Importe_Despues_Copago_Total, "|",
                                                                    x.Monto_Unitario_IVA, "|",
                                                                    x.Monto_Total_IVA, "|",
                                                                    x.Total, "|",
                                                                    x.Numero_de_Sucursal, "|",
                                                                    x.EAN, "|",
                                                                    x.Nombre_de_Sucursal, "|",
                                                                    x.Precio_Bruto_Unitario_POS, "|",
                                                                    x.Precio_Bruto_POS, "|",
                                                                    x.Nombre_de_la_cuenta_del_dispensador, Environment.NewLine
                                                            ));
                                StreamWriter sw = new StreamWriter(_TempBackup + @"\" + file.Name);
                                sw.Write(header + _Text);
                                sw.Close();
                                DirectoryInfo directorio = new DirectoryInfo(_TempBackup);
                                FileInfo[] files = directorio.GetFiles("*.csv");
                                foreach (FileInfo _FileInfo in files)
                                {
                                    if (_FileInfo.Name == file.Name)
                                    {
                                        var op = SaveFileMedikit(_FileInfo, _UserFtp, _PasswordFtp, "Layouts//backup");
                                    }
                                }
                            }
                            if (_ListErrores.Count > 0)
                            {
                                string _Text = string.Empty;
                                string header = "NUR|Paciente|Doctor|Nombre|Dispensacion_de_medicamentos" +
                                "|Fecha_de_creacion|Creado_por|Ultima_modificacion|Ultima_modificacion_por|Estatus" +
                                "|Nombre_Medicacion|Receta_relacionada|Cantidad|Fecha_Dispensada|Ticket|Precio_Venta_Unitario_(AC)" +
                                "|Descuento%|Descuento_Monto_Unitario|Descuento_Monto_por_cantidad_de_piezas_surtidas" +
                                "|Precio_MAC_Unitario|Precio_MAC_Total|IVA%|IVA_identificador_por_medicamento|Copago%" +
                                "|Monto_Copago_Unitario|Monto_Copago_Total|Importe_Despues_Copago_Unitario" +
                                "|Importe_Despues_Copago_Total|Monto_Unitario_IVA|Monto_Total_IVA|Total|Numero_de_Sucursal" +
                                "|EAN|Nombre_de_Sucursal|Precio_Bruto_Unitario_POS|Precio_Bruto_POS|Nombre_de_la_cuenta_del_dispensador" + Environment.NewLine;
                                _ListErrores.ForEach(x =>
                                _Text = string.Concat(_Text,
                                        x.Nur, "|",
                                        x.Paciente, "|",
                                        x.Doctor, "|",
                                        x.Nombre, "|",
                                        x.Dispensacion_de_medicamentos, "|",
                                        x.Fecha_de_creacion, "|",
                                        x.Creado_por, "|",
                                        x.Ultima_modificacion, "|",
                                        x.Ultima_modificacion_por, "|",
                                        x.Estatus, "|",
                                        x.Nombre_Medicacion, "|",
                                        x.Receta_relacionada, "|",
                                        x.Cantidad, "|",
                                        x.Fecha_Dispensada, "|",
                                        x.Ticket, "|",
                                        x.Precio_Venta_Unitario_AC, "|",
                                        x.DescuentoPorcentaje, "|",
                                        x.Descuento_Monto_Unitario, "|",
                                        x.Descuento_Monto_por_cantidad_de_piezas_surtidas, "|",
                                        x.Precio_MAC_Unitario, "|",
                                        x.Precio_MAC_Total, "|",
                                        x.IVAPorcentaje, "|",
                                        x.IVA_identificador_por_medicamento, "|",
                                        x.CopagoPorcentaje, "|",
                                        x.Monto_Copago_Unitario, "|",
                                        x.Monto_Copago_Total, "|",
                                        x.Importe_Despues_Copago_Unitario, "|",
                                        x.Importe_Despues_Copago_Total, "|",
                                        x.Monto_Unitario_IVA, "|",
                                        x.Monto_Total_IVA, "|",
                                        x.Total, "|",
                                        x.Numero_de_Sucursal, "|",
                                        x.EAN, "|",
                                        x.Nombre_de_Sucursal, "|",
                                        x.Precio_Bruto_Unitario_POS, "|",
                                        x.Precio_Bruto_POS, "|",
                                        x.Nombre_de_la_cuenta_del_dispensador, Environment.NewLine
                                ));
                                StreamWriter sw = new StreamWriter(_Temperrors + @"\" + file.Name);
                                sw.Write(header + _Text);
                                sw.Close();
                                DirectoryInfo directorio = new DirectoryInfo(_Temperrors);
                                FileInfo[] files = directorio.GetFiles("*.csv");
                                foreach (FileInfo _FileInfo in files)
                                {
                                    if (_FileInfo.Name == file.Name)
                                    {
                                        var op = SaveFileMedikit(_FileInfo, _UserFtp, _PasswordFtp, "Layouts//errors");
                                    }
                                }
                            }
                        }
                        foreach (var item in _NamesFileList)
                        {
                            string delete = DeleteFileFTP(item.Nombre, _Folder, _UserFtp, _PasswordFtp);
                        }
                        DeleteFileDirectory(_TempPath, "*.csv");
                        DeleteFileDirectory(_TempBackup, "*.csv");
                        DeleteFileDirectory(_Temperrors, "*.csv");
                    }
                    else
                    {
                        _Response.SetStatusCode(OperationResult.StatusCodesEnum.NOT_FOUND);
                        _Response.AddException(new Exception("No se encontrarón resultados"));
                        return _Response;
                    }
                }
                else
                {
                    _Response.SetStatusCode(OperationResult.StatusCodesEnum.NOT_FOUND);
                    _Response.AddException(new Exception("No se encontrarón archivos en el FTP"));
                    return _Response;
                }
            }
            catch (Exception ex)
            {
                this._Logger.LogError(ex);
                _Response.SetStatusCode(OperationResult.StatusCodesEnum.INTERNAL_SERVER_ERROR);
                _Response.AddException(ex);

            }
            return _Response;
        }