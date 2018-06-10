//
//  TeamTableView.swift
//  lolStalker
//
//  Created by Muhand Jumah on 6/8/18.
//  Copyright © 2018 Muhand Jumah. All rights reserved.
//

import Foundation
import UIKit

//protocol TeamViewDelegate:UITableViewDelegate {
//    //    func didPressSignup(form: GameView)
//    //    func didPressAlreadyHaveAccount(form: GameView)
////    func didTapAPlayer(form: TeamTableView)
//}

class TeamTableView: UITableView, UITableViewDelegate, UITableViewDataSource {
    ////////////////////////////////////
    //            Delegates
    ////////////////////////////////////
//    var delegate: TeamViewDelegate?
    
    private struct TableViewReuseIDs {
        static let player = "playerId"
    }
    
    ////////////////////////////////////
    //Global Variables
    ////////////////////////////////////
    var team: Team? {
        didSet{
            self.reloadData()
        }
    }
    
//    override func viewDidLoad() {
//        setUpView()
//        registerCells()
////        print("LOAD: \(team?.players.count)")
//    }
//
//    override func viewDidAppear(_ animated: Bool) {
//        print("APPEAR: \(team?.players.count)")
//        reloadData()
//    }
    override init(frame: CGRect, style: UITableViewStyle) {
        super.init(frame: frame, style: style)
        self.delegate = self
        self.dataSource = self
        setUpView()
        registerCells()
    }
    
    required init?(coder aDecoder: NSCoder) {
        fatalError("init(coder:) has not been implemented")
    }
    
    func setUpView() {
        cellLayoutMarginsFollowReadableWidth = false
        backgroundColor =  UIColor(hex: "#010A13")
        separatorStyle = .none
        alwaysBounceVertical = true
    }
    
    func registerCells() {
        register(PlayerViewCell.self, forCellReuseIdentifier: TableViewReuseIDs.player)
    }
    func tableView(_ tableView: UITableView, numberOfRowsInSection section: Int) -> Int {
        if let teamSize = team?.TEAMSIZE {
            restore()
            return teamSize
        } else {
            setEmptyMessage("No Teams Yet")
            return 0
        }
    }
    
    func tableView(_ tableView: UITableView, cellForRowAt indexPath: IndexPath) -> UITableViewCell {
        let player = dequeueReusableCell(withIdentifier: TableViewReuseIDs.player, for: indexPath) as! PlayerViewCell
        player.player = team?.players[indexPath.item]
        return player
    }
    
    func tableView(_ tableView: UITableView, heightForRowAt indexPath: IndexPath) -> CGFloat {
        return Helper.getHeightOf(xdHeight: 50, referenceHeight: 250, originalHeight: frame.height)
    }
    
    func tableView(_ tableView: UITableView, didSelectRowAt indexPath: IndexPath) {
        //        let playerCell:UITableViewCell = tableView.cellForRow(at: indexPath)! as! PlayerViewCell
        let playerViewController = PlayerViewController()
        playerViewController.modalPresentationStyle = UIModalPresentationStyle.fullScreen
        UIApplication.shared.keyWindow?.rootViewController?.present(playerViewController, animated: true, completion: nil)
        
//        tableView.deselectRow(at: indexPath, animated: false)
    }
    
//    override func tableView(_ tableView: UITableView, didDeselectRowAt indexPath: IndexPath) {
//        let cellToDeSelect:UITableViewCell = tableView.cellForRow(at: indexPath)!
//        print("DESELECTED")
//        cellToDeSelect.contentView.backgroundColor = .clear
//    }
    
}
