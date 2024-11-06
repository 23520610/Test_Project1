using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace WpfApp3.ViewModel
{
    public class SinhVienViewModel : BaseViewModel
    {
        // Các thuộc tính cho sinh viên
        private string _maSo;
        public string MaSo
        {
            get => _maSo;
            set
            {
                _maSo = value;
                OnPropertyChanged();
            }
        }

        private string _hoTen;
        public string HoTen
        {
            get => _hoTen;
            set
            {
                _hoTen = value;
                OnPropertyChanged();
            }
        }

        private DateTime _ngaySinh;
        public DateTime NgaySinh
        {
            get => _ngaySinh;
            set
            {
                _ngaySinh = value;
                OnPropertyChanged();
            }
        }

        private string _gioiTinh;
        public string GioiTinh
        {
            get => _gioiTinh;
            set
            {
                _gioiTinh = value;
                OnPropertyChanged();
            }
        }

        private string _diaChi;
        public string DiaChi
        {
            get => _diaChi;
            set
            {
                _diaChi = value;
                OnPropertyChanged();
            }
        }

        private string _dienThoai;
        public string DienThoai
        {
            get => _dienThoai;
            set
            {
                _dienThoai = value;
                OnPropertyChanged();
            }
        }

        // Danh sách sinh viên
        public ObservableCollection<SinhVienViewModel> DanhSachSinhVien { get; set; }

        // Các lệnh
        public ICommand ThemMoiCommand { get; set; }
        public ICommand GhiCommand { get; set; }
        public ICommand SuaCommand { get; set; }
        public ICommand XoaCommand { get; set; }

        public SinhVienViewModel()
        {
            DanhSachSinhVien = new ObservableCollection<SinhVienViewModel>();

            // Khởi tạo các lệnh
            ThemMoiCommand = new RelayCommand<object>((p) => true, (p) => ThemMoi());
            GhiCommand = new RelayCommand<object>((p) => true, (p) => Ghi());
            SuaCommand = new RelayCommand<object>((p) => true, (p) => Sua());
            XoaCommand = new RelayCommand<object>((p) => true, (p) => Xoa());
        }

        // Phương thức để Thêm mới
        private void ThemMoi()
        {
            var sinhVienMoi = new SinhVienViewModel
            {
                MaSo = this.MaSo,
                HoTen = this.HoTen,
                NgaySinh = this.NgaySinh,
                GioiTinh = this.GioiTinh,
                DiaChi = this.DiaChi,
                DienThoai = this.DienThoai
            };

            DanhSachSinhVien.Add(sinhVienMoi);
            ClearInput();
        }

        // Phương thức để Ghi (Save)
        private void Ghi()
        {
            // Thực hiện lưu vào database hoặc xử lý logic ghi ở đây
            // Bạn có thể sử dụng Entity Framework Core để thao tác với CSDL
        }

        // Phương thức để Sửa
        private void Sua()
        {
            // Thực hiện sửa thông tin sinh viên được chọn trong DanhSachSinhVien
            // Cập nhật thông tin vào cơ sở dữ liệu
        }

        // Phương thức để Xóa
        private void Xoa()
        {
            var sinhVienCanXoa = DanhSachSinhVien.FirstOrDefault(sv => sv.MaSo == this.MaSo);
            if (sinhVienCanXoa != null)
            {
                DanhSachSinhVien.Remove(sinhVienCanXoa);
            }
            ClearInput();
        }

        // Phương thức xóa dữ liệu nhập
        private void ClearInput()
        {
            MaSo = string.Empty;
            HoTen = string.Empty;
            NgaySinh = DateTime.Now;
            GioiTinh = string.Empty;
            DiaChi = string.Empty;
            DienThoai = string.Empty;
        }
    }
}
