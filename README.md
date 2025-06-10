# 🎮 6Chapter_Solo – 3D 방치형 RPG 구현

Unity 기반 3D 방치형 RPG 게임 구현 프로젝트입니다. 다양한 시스템을 유기적으로 연결하여 RPG의 기본 구조를 설계하고, 방치형 요소까지 고려한 개인 프로젝트입니다.

---

## ✅ 주요 기능

### 🔹 필수 구현

- 기본 UI 시스템  
- 플레이어 AI 시스템  
- 아이템 및 업그레이드 시스템  
- 게임 내 통화(Gold) 시스템  
- 장비 인벤토리 UI  
- 스테이지 진행 시스템  
- ScriptableObject 기반 데이터 관리  

### 🔸 선택 구현

- 사운드 이펙트 시스템  
- 저장 및 로드 시스템  

---

## 🧩 기능 상세 설명

### 📌 기본 UI 구현
- 능력치 및 상호작용 버튼 UI 제공  
- 제한된 리소스 내에서 Outline, 색상, 텍스트로 가독성 확보  
![UI Image](https://github.com/user-attachments/assets/445edadf-8029-45e7-a444-3dd90a04bfcc)

---

### 🤖 플레이어 AI 시스템
- 몬스터와의 거리 계산 → 최단 거리 적 추적  
- 일정 거리 이내 접근 시 공격 상태로 전환  
![AI Image](https://github.com/user-attachments/assets/47097b6d-a393-484e-a87a-619142b9c29e)

---

### 🛡️ 아이템 및 업그레이드 시스템
- 공격력, 체력, 속도 등 능력치를 골드로 구매 가능  
- 능력치가 실시간으로 Player에 반영  
![Upgrade System](https://github.com/user-attachments/assets/f8d51cad-55ac-4225-8daf-798d19954846)

---

### 💰 게임 내 통화 시스템
- 몬스터 처치 시 골드 획득  
- 업그레이드 및 아이템 구매에 사용  

---

### 🎒 아이템 및 장비창 UI
- 장비 아이템 장착 / 해제 기능  
- 드랍 아이템 스택 구현 → 방치형 설계 반영  
![Inventory](https://github.com/user-attachments/assets/7aa42c0d-a986-4690-94d5-52ebd7fdf5d4)

---

### 🗺️ 스테이지 시스템
- `ScriptableObject`를 통한 각 Stage 구성  
- `MonsterSpawner`에서 `List<Stage>`를 참조하여 몬스터 생성  
![Stage](https://github.com/user-attachments/assets/364ac56e-cb91-47fe-8564-11277a2b4992)

---

### 🧱 ScriptableObject 기반 데이터 관리
- `ItemData` → `InventoryItem`, `EquipItem`, `ResourceItem` 등으로 세분화  
- `Player`, `Enemy`, `Item`, `Stage` 등 객체별 데이터 지정  
![SO Image](https://github.com/user-attachments/assets/0cccbfba-3dae-4b05-90ad-17a810b0009a)

---

### 🔊 사운드 이펙트
- 공격, 이동
